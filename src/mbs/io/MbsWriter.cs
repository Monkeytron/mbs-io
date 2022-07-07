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

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsWriter : MbsIO
    {
        public ByteArray bytes;

        private Dictionary<string, TableRecord> stringTable;
        private int stringTableIndex = -1;

        private Dictionary<MbsType, TableRecord> typeTable;
        private int typeTableIndex = -1;

        private bool storeTypeInformation;
        private MbsTypedefSet typedefSet;

        private MbsHeader header;

        private int mbsVersion;

        /// <param name="version">If left null, uses the current version from MbsVersionControl. However, if you are writing for games that use old versions this is supported too.</param>
        /// <param name="typeTableHash"> If left null, uses the current typedefset from MbsVersionControl. However, if you are writing for games that use old typedefs that is supported too.</param>
        public MbsWriter(int? typeTableHash, bool storeTypeInformation, int? version)
        {
            bytes = new ByteArray();
            stringTable = new Dictionary<string, TableRecord>();
            typeTable = new Dictionary<MbsType, TableRecord>();

            header = new MbsHeader(this);
            typeWriter = new MbsTypeInfo(this);

            typedefSet = MbsVersionControl.ALLCURRENTVERSIONS.getTypedefSet(typeTableHash.GetValueOrDefault(MbsVersionControl.LATESTVERSION.Item2));
            this.storeTypeInformation = storeTypeInformation;

            // Allocate a HEADER_INFO before anything else so it has a constant placement at the start of the file.
            header.allocateNew();

            //Ensure the empty string is placed at index 0 in the string table.
            getStringIndex("");

            if (storeTypeInformation)
            {
                foreach (MbsType type in mbsVersion <= 1 ? typedefSet.getTypes().Where(i => i != MbsTypes.NULL):typedefSet.getTypes())
                {
                    registerType(type);
                } // Botching the "Mbs version 1 didn't have null type and that throws off the type table" problem 
            }

            header.setVersion(version.GetValueOrDefault(MbsVersionControl.LATESTVERSION.Item1));
            header.setTypeTableHash(typedefSet.getHash());
        }

        public override int allocate(int size)
        {
            return bytes.allocate(size);
        }

        public void setRoot(MbsObject obj)
        {
            header.setRoot(obj);
        }

        public void prepareForOutput()
        {
            //enter data manually in a format similar to lists, but without typecodes.
            //we won't know the typecodes anyway when reading back in.

            int intSize = MbsTypes.INTEGER.getSize();
            int listAddress = bytes.allocate(intSize + intSize * (stringTableIndex + 1));
            bytes.writeInt(listAddress, (stringTableIndex + 1));

            foreach (TableRecord record in stringTable.Values)
            {
                bytes.writeInt(listAddress + intSize + (record.index * intSize), record.address);
            }

            header.setStringTablePointer(listAddress);

            if (storeTypeInformation)
            {
                listAddress = bytes.allocate(intSize + intSize * (typeTableIndex + 1));
                bytes.writeInt(listAddress, (typeTableIndex + 1));

                foreach (TableRecord record in typeTable.Values)
                {
                    bytes.writeInt(listAddress + intSize + (record.index * intSize), record.address);
                }

                header.setTypeTablePointer(listAddress);
            }

        }

        public void writeToFile(string loc)
        {
            bytes.writeToFile(loc);
        }

        public override void writeBool(int address, bool value)
        {
            bytes.writeBool(address, value);
        }
        public override void writeFloat(int address, float value)
        {
            bytes.writeFloat(address, value);
        }
        public override void writeInt(int address, int value)
        {
            bytes.writeInt(address, value);
        }
        public override void writeString(int address, string value)
        {
            bytes.writeInt(address, getStringIndex(value));
        }

        // Type Table

        private MbsTypeInfo typeWriter;

        public void registerType(MbsType type)
        {
            if (!typeTable.ContainsKey(type))
            {
                typeWriter.allocateNew();
                typeWriter.setName(type.getName());
                typeWriter.setSize(type.getSize());

                if (type is ComposedType)
                {
                    ComposedType cType = (ComposedType)type;

                    if (cType.getParent() is not null)
                    {
                        typeWriter.setParent(cType.getParent().getName());
                    }

                    if (cType.getFields().Length != 0)
                    {
                        MbsFieldInfo fieldWriter = new MbsFieldInfo(this);

                        int fields = bytes.allocate(MbsTypes.INTEGER.getSize() + fieldWriter.getMbsType().getSize() * cType.getFields().Length);
                        typeWriter.setFieldsPointer(fields);
                        writeInt(fields, cType.getFields().Length);
                        fields += MbsTypes.INTEGER.getSize();

                        foreach (MbsField field in cType.getFields())
                        {
                            fieldWriter.setAddress(fields);
                            fields += fieldWriter.getMbsType().getSize();

                            fieldWriter.setName(field.getName());
                            fieldWriter.setType(field.getType().getName());
                            fieldWriter.setFieldAddress(field.getAddress());
                        }
                    }
                }

                TableRecord r = new TableRecord(typeWriter.getAddress(), ++typeTableIndex);
                if (typeTable.ContainsKey(type)) typeTable[type] = r;
                else typeTable.Add(type, r);
            }
        }

        public override void writeTypecode(int address, MbsType type)
        {
            if (storeTypeInformation) bytes.writeInt(address, typeTable[type].index);

            else
            {
                int typecode = typedefSet.getTypecode(type);
                if (mbsVersion <= 1)
                {
                    if (typecode == typedefSet.getTypecode(MbsTypes.NULL)) throw new Exception("NULL type did not exist in MBS version 1");
                    else if (typecode > typedefSet.getTypecode(MbsTypes.NULL)) typecode -= 1;
                } // Mbs version 1 NULL type fiasco
                bytes.writeInt(address, typecode);
            }
        }

        // String Table

        public int getStringIndex(string value)
        {
            if (!stringTable.ContainsKey(value))
            {
                Byte[] asBytes = value.ToCharArray().Select(i => (byte)i).ToArray();

                int newString = bytes.allocate(asBytes.Length + 4);

                bytes.writeInt(newString, asBytes.Length);
                bytes.writeBytes(newString + 4, asBytes);

                TableRecord r = new TableRecord(newString, ++stringTableIndex);
                stringTable.Add(value, r);
            }

            return stringTable[value].index;
        }

        public override bool readBool(int address)
        {
            throw new Exception("Can't read on an MBS writer");
        }
        public override float readFloat(int address)
        {
            throw new Exception("Can't read on an MBS writer");
        }
        public override int readInt(int address)
        {
            throw new Exception("Can't read on an MBS writer");
        }
        public override string readString(int address)
        {
            throw new Exception("Can't read on an MBS writer");
        }
        public override bool isReader()
        {
            return false;
        }
        public override bool isWriter()
        {
            return true;
        }
        public override MbsType readTypecode(int address)
        {
            throw new Exception("Can't read on an MBS writer");
        }
    }



    class TableRecord
    {
        public int address;
        public int index;
        public TableRecord(int address, int index)
        {
            this.address = address; this.index = index;
        }
    }
}
