using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core.header
{
    public class MbsTypeInfo : MbsObject
    {
        public static MbsField name;
        public static MbsField parent;
        public static MbsField fieldsPointer;
        public static MbsField size;

        public static ComposedType MBS_TYPE_INFO;

        static MbsTypeInfo()
        {
            MBS_TYPE_INFO = new ComposedType("MbsTypeInfo");
            MBS_TYPE_INFO.setInstantiator(data => new MbsTypeInfo(data));

            name = MBS_TYPE_INFO.createField("name", MbsTypes.STRING);
            parent = MBS_TYPE_INFO.createField("parent", MbsTypes.STRING);
            fieldsPointer = MBS_TYPE_INFO.createField("fieldsPointer", MbsTypes.INTEGER);
            size = MBS_TYPE_INFO.createField("size", MbsTypes.INTEGER);
        }

        public static MbsList<MbsTypeInfo> new_MbsTypeInfo_list(MbsIO data)
        {
            return new MbsList<MbsTypeInfo>(data, MBS_TYPE_INFO, new MbsTypeInfo(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_TYPE_INFO;
        }

        public MbsTypeInfo(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_TYPE_INFO.getSize()));
        }

        public string getName()
        {
            return data.readString(address + name.address);
        }
        public void setName(string _val)
        {
            data.writeString(address + name.address, _val);
        }

        public string getParent()
        {
            return data.readString(address + parent.address);
        }
        public void setParent(string _val)
        {
            data.writeString(address + parent.address, _val);
        }

        public int getFieldsPointer()
        {
            return data.readInt(address + fieldsPointer.address);
        }
        public void setFieldsPointer(int _val)
        {
            data.writeInt(address + fieldsPointer.address, _val);
        }

        public int getSize()
        {
            return data.readInt(address + size.address);
        }
        public void setSize(int _val)
        {
            data.writeInt(address + size.address, _val);
        }
    }
}
