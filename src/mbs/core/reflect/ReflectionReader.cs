using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core.reflect
{
    public class ReflectionReader:MbsReader
    {
        public ReflectionReader(MbsVersionControl validVersions, bool readStoredTypeInformation, bool initStringList) : base(validVersions, readStoredTypeInformation, initStringList)
        {

        }

        public void traceInfo()
        {
            Console.WriteLine($"TYPES:\n{typeTable}\n\nSTRINGS:\n{stringTable}\n\nROOT:\n{getRoot()}");
        }

        public dynamic getReflectedRoot()
        {
            dynamic root = header.getRoot();

            if (root is MbsListBase)
            {
                MbsListBase m1 = (MbsListBase)root;
                return readList(m1.getAddress());
            }
            else if (root is MbsObject)
            {
                MbsObject mo = (MbsObject)root;
                return readObject(mo.getMbsType(), mo.getAddress());
            }
            else return root;
        }

        private Dictionary<string,dynamic> readObject(MbsType type, int address)
        {
            Dictionary<string, dynamic> obj = new Dictionary<string, dynamic>();
            ComposedType st = (ComposedType)type;

            MbsField[] fields = new MbsField[0];

            while(st is not null)
            {
                if (st.getFields() is not null) fields = fields.Concat(st.getFields()).ToArray();
                st = st.getParent();
            }

            MbsGenericObject genObj = new MbsGenericObject(this, type);
            genObj.setAddress(address);
            foreach(MbsField f in fields)
            {
                if (obj.ContainsKey(f.getName())) obj[f.getName()] = readField(genObj, f);
                else obj.Add(f.getName(), readField(genObj, f));
            }

            return obj;
        }

        private dynamic readField(MbsGenericObject r, MbsField f)
        {
            switch (f.type.getName())
            {
                case "boolean": return r.readBool(f);
                case "integer": return r.readInt(f);
                case "float": return r.readFloat(f);
                case "string": return r.readString(f);
                case "list": return readList(r.readInt(f));
                case "dynamic": return readDynamic(r.getAddress() + f.address);
                default: return readObject(f.type, r.getAddress() + f.address);
            }
        }

        private dynamic[] readList(int address)
        {
            if (address == 0) return new dynamic[0];

            int length = readInt(address);
            dynamic[] list = new dynamic[length];
            MbsType type =  readTypecode(address + MbsTypes.INTEGER.getSize());

            var readAddress = address + MbsTypes.INTEGER.getSize() * 2;

            for(int i = 0; i < length; i++)
            {
                switch (type.getName())
                {
                    case "boolean": list[i] = readBool(readAddress); break;
                    case "integer": list[i] = readInt(readAddress); break;
                    case "float": list[i] = readFloat(readAddress); break;
                    case "string": list[i] = readString(readAddress); break;
                    case "dynamic": list[i] = readDynamic(readAddress); break;
                    default: list[i] = readObject(type, readAddress); break;
                }
                readAddress += type.getSize();
            }
            return list;
        }

        private dynamic readDynamic(int address)
        {
            MbsType type = readTypecode(address);

            switch (type.getName())
            {
                case "null": return null;
                case "boolean": return readBool(address + MbsTypes.INTEGER.getSize());
                case "integer": return readInt(address + MbsTypes.INTEGER.getSize());
                case "float": return readFloat(address + MbsTypes.INTEGER.getSize());
                case "string": return readString(address + MbsTypes.INTEGER.getSize());
                case "list": return readList(readInt(address + MbsTypes.INTEGER.getSize()));
                case "dynamic": return readDynamic(readInt(address + MbsTypes.INTEGER.getSize()));
                default: return readObject(type, readInt(address + MbsTypes.INTEGER.getSize()));
            }
        }
    }
}
