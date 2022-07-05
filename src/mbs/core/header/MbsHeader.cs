using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core.header
{
    public class MbsHeader : MbsObject
    {
        public static MbsField version;
        public static MbsField typeTableHash;
        public static MbsField typeTablePointer;
        public static MbsField stringTablePointer;
        public static MbsField root;

        public static ComposedType MBS_HEADER;

        static MbsHeader()
        {
            MBS_HEADER = new ComposedType("MbsHeader");
            MBS_HEADER.setInstantiator(data => new MbsHeader(data));

            version = MBS_HEADER.createField("version", MbsTypes.INTEGER);
            typeTableHash = MBS_HEADER.createField("typeTableHash", MbsTypes.INTEGER);
            typeTablePointer = MBS_HEADER.createField("typeTablePointer", MbsTypes.INTEGER);
            stringTablePointer = MBS_HEADER.createField("stringTablePointer", MbsTypes.INTEGER);
            root = MBS_HEADER.createField("root", MbsTypes.DYNAMIC);
        }

        public static MbsList<MbsHeader> new_MbsHeader_list(MbsIO data)
        {
            return new MbsList<MbsHeader>(data, MBS_HEADER, new MbsHeader(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_HEADER;
        }

        public MbsHeader(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_HEADER.getSize()));
        }

        public int getVersion()
        {
            return data.readInt(address + version.address);
        }
        public void setVersion(int _val)
        {
            data.writeInt(address + version.address, _val);
        }

        public int getTypeTableHash()
        {
            return data.readInt(address + typeTableHash.address);
        }
        public void setTypeTableHash(int _val)
        {
            data.writeInt(address + typeTableHash.address, _val);
        }

        public int getTypeTablePointer()
        {
            return data.readInt(address + typeTablePointer.address);
        }
        public void setTypeTablePointer(int _val)
        {
            data.writeInt(address + typeTablePointer.address, _val);
        }

        public int getStringTablePointer()
        {
            return data.readInt(address + stringTablePointer.address);
        }
        public void setStringTablePointer(int _val)
        {
            data.writeInt(address + stringTablePointer.address, _val);
        }

        public dynamic getRoot()
        {
            return MbsDynamicHelper.readDynamic(data, address + root.address);
        }
        public void setRoot(dynamic _val)
        {
            MbsDynamicHelper.writeDynamic(data, address + root.address, _val);
        }
    }
}
