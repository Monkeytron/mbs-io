using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiscUtil.Conversion;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.core.header;
using haxe_mbs_translate.src.mbs.core.reflect;

using System.Xml;

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsReader : MbsIO
    {
        public Byte[] data;

        protected string[] stringTable;
        protected MbsType[] typeTable;
        private int rootAddress;

        private Dictionary<string, MbsType> subTypeMap;

        private bool initStringList;
        private int stringTableAddress;

        private bool readStoredTypeInformation;
        private MbsTypedefSet typedefSet;

        private int mbsVersion;

        private MbsVersionControl validVersions;

        protected MbsHeader header;

        public MbsReader(MbsVersionControl validVersions, bool readStoredTypeInformation, bool initStringList)
        {
            this.validVersions = validVersions;
            this.readStoredTypeInformation = readStoredTypeInformation;
            this.initStringList = initStringList;

            header = new MbsHeader(this);
            header.setAddress(0);
        }

        public string canReadFile(string file)
        {
            Byte[] bytes = File.ReadAllBytes(file).Take(header.getMbsType().getSize()).ToArray();

            return canRead(bytes);
        }

        public string canRead(Byte[] bytes)
        {
            List<string> errors = new List<string>();

            if (bytes is null || bytes.Length < header.getMbsType().getSize()) errors.Add("Missing header");

            this.data = bytes;
            int readVersion = header.getVersion();
            if (!validVersions.isValidMbsVersion(readVersion)) errors.Add($"Mismatched version -- {readVersion}");


            int readHash = header.getTypeTableHash();
            if (!validVersions.isKnownHash(readHash)) errors.Add($"Unknown typetable -- {readHash}");

            if (readStoredTypeInformation && header.getTypeTablePointer() == 0) errors.Add("Missing required type information");

            data = null;

            return string.Join("\n+\n", errors);
        }

        /// <returns>(mbsVersion, typeTableHash)</returns>
        public (int, int) readData(Byte[] bytes)
        {
            data = bytes;

            mbsVersion = header.getVersion();

            if (!validVersions.isValidMbsVersion(mbsVersion)) throw new Exception($"Mismatched version -- {mbsVersion}");

            typedefSet = validVersions.getTypedefSet(header.getTypeTableHash());

            Console.WriteLine($"Version = {mbsVersion} and typeset = {typedefSet.getHash()}");

            int intSize = MbsTypes.INTEGER.getSize();

            int readAddress = 0;

            stringTableAddress = header.getStringTablePointer();
            stringTable = new string[readInt(stringTableAddress)];

            if (initStringList)
            {
                readAddress = stringTableAddress + intSize;
                for (int i = 0; i < stringTable.Length; i++)
                {
                    int pos = readInt(readAddress);
                    int length = readInt(pos);
                    stringTable[i] = string.Concat(data.Skip(pos + 4).Take(length).Select(i => (char)i));
                    readAddress += intSize;
                }
            }

            if (readStoredTypeInformation)
            {
                MbsTypeInfo typeInfo = new MbsTypeInfo(this);

                readAddress = header.getTypeTablePointer();
                typeTable = new MbsType[readInt(readAddress)];
                readAddress += intSize;

                subTypeMap = new Dictionary<string, MbsType>();
                Dictionary<string, MbsType> primTypeMap = new Dictionary<string, MbsType>
                {
                    { MbsTypes.BOOLEAN.getName(),MbsTypes.BOOLEAN },
                    { MbsTypes.INTEGER.getName(),MbsTypes.INTEGER },
                    { MbsTypes.FLOAT.getName(),MbsTypes.FLOAT },
                    { MbsTypes.STRING.getName(),MbsTypes.STRING },
                    { MbsTypes.DYNAMIC.getName(),MbsTypes.DYNAMIC },
                    { MbsTypes.LIST.getName(),MbsTypes.LIST },
                };

                for (int i = 0; i < typeTable.Length; i++)
                {
                    typeInfo.setAddress(readInt(readAddress));
                    readAddress += intSize;

                    string name = typeInfo.getName();
                    string parentType = typeInfo.getParent();
                    int size = typeInfo.getSize();
                    MbsField[] fields = null;

                    int fieldListAddress = typeInfo.getFieldsPointer();
                    if (fieldListAddress != 0)
                    {
                        int fieldListLength = readInt(fieldListAddress);
                        fieldListAddress += intSize;

                        fields = new MbsField[fieldListLength];
                        MbsFieldInfo fieldInfo = new MbsFieldInfo(this);

                        for (int j = 0; j < fieldListLength; j++)
                        {
                            fieldInfo.setAddress(fieldListAddress);
                            fieldListAddress += MbsFieldInfo.MBS_FIELD_INFO.getSize();

                            string fieldName = fieldInfo.getName();
                            string fieldType = fieldInfo.getType();
                            int fieldAddress = fieldInfo.getAddress();

                            fields[j] = new SubstituteField(fieldName, fieldType, fieldAddress);
                        }
                    }

                    if (primTypeMap.ContainsKey(name)) typeTable[i] = primTypeMap[name];
                    else typeTable[i] = new SubstituteType(name, parentType, fields, size);

                    if (subTypeMap.ContainsKey(name)) subTypeMap[name] = typeTable[i];
                    else subTypeMap.Add(name, typeTable[i]);
                }

                for (int i = 0; i < typeTable.Length; i++)
                {
                    if (typeTable[i] is not SubstituteType) continue;

                    ((SubstituteType)typeTable[i]).mapTypes(subTypeMap);
                }
            }

            else
            {
                if (mbsVersion <= 1)
                {
                    typeTable = new MbsType[typedefSet.getTypes().Length - 1];
                    foreach (MbsType type in typedefSet.getTypes())
                    {
                        int typeCode = typedefSet.getTypecode(type);
                        if (typeCode < typedefSet.getTypecode(MbsTypes.NULL)) typeTable[typedefSet.getTypecode(type)] = type;
                        else if (typeCode > typedefSet.getTypecode(MbsTypes.NULL)) typeTable[typedefSet.getTypecode(type) - 1] = type;
                    }
                }
                else
                {
                    typeTable = new MbsType[typedefSet.getTypes().Length];
                    foreach (MbsType type in typedefSet.getTypes())
                    {
                        typeTable[typedefSet.getTypecode(type)] = type;
                    }
                }
                // MbsVersion 1 didn't have null type but version 2 did.
                // This means that I have to botch this code a bit to ignore NULL in typedefset, so that their indexes match up as if null was never there.
            }


            return (mbsVersion, typedefSet.getHash());
        }

        public void reconfigureComposition(ComposedType type)
        {
            if (subTypeMap.ContainsKey(type.getName()))
            {
                ComposedType subType = (ComposedType)subTypeMap[type.getName()];
                Dictionary<string, MbsField> fieldMap = new Dictionary<string, MbsField>();

                foreach (MbsField f in subType.getFields())
                {
                    if (fieldMap.ContainsKey(f.getName())) fieldMap[f.getName()] = f;
                    else fieldMap.Add(f.getName(), f);
                }

                foreach(MbsField f in type.getFields())
                {
                    f.address = fieldMap[f.getName()].address;
                }
            }
        }

        public dynamic getRoot()
        {
            return header.getRoot();
        }

        public override int readInt(int pos)
        {
            return EndianBitConverter.Big.ToInt32(data, pos);
        }
        public override bool readBool(int pos)
        {
            return EndianBitConverter.Big.ToBoolean(data, pos);
        }
        public override float readFloat(int pos)
        {
            return EndianBitConverter.Big.ToSingle(data, pos);
        }
        public override string readString(int pos)
        {
            if (initStringList) return stringTable[readInt(pos)];

            int stringAddress = readInt(pos);
            if(stringTable[stringAddress] == null)
            {
                int stringPos = readInt(stringTableAddress + MbsTypes.INTEGER.getSize() * (stringAddress + 1));
                int length = readInt(stringPos);
                stringTable[stringAddress] = string.Concat(data.Skip(stringPos + 4).Take(length).Select(i => (char)i));
            }

            return stringTable[stringAddress];
        }

        public override MbsType readTypecode(int pos)
        {
            int typeCode = readInt(pos);
            return typeTable[typeCode];
        }
        public MbsType[] getTypeTable()
        {
            return typeTable;
        }

        public override void writeInt(int address, int value)
        {
            throw new Exception("Can't write on an MBS reader");
        }

        public override void writeBool(int address, bool value)
        {
            throw new Exception("Can't write on an MBS reader");
        }

        public override void writeFloat(int address, float value)
        {
            throw new Exception("Can't write on an MBS reader");
        }

        public override void writeString(int address, string value)
        {
            throw new Exception("Can't write on an MBS reader");
        }

        public override bool isReader()
        {
            return true;
        }

        public override bool isWriter()
        {
            return false;
        }

        public override int allocate(int size)
        {
            throw new Exception("Can't allocate on an MBS reader");
        }
        public override void writeTypecode(int address, MbsType type)
        {
            throw new Exception("Can't write on an MBS reader");
        }
    }
}
