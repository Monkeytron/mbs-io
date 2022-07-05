using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core.header
{
    public class MbsFieldInfo:MbsObject
    {
        public static MbsField name;
        public static MbsField type;
        public static MbsField fieldAddress;

        public static ComposedType MBS_FIELD_INFO;

        static MbsFieldInfo()
        {
            MBS_FIELD_INFO = new ComposedType("MbsFieldInfo");
            MBS_FIELD_INFO.setInstantiator(data => new MbsFieldInfo(data));

            name = MBS_FIELD_INFO.createField("name", MbsTypes.STRING);
            type = MBS_FIELD_INFO.createField("type", MbsTypes.STRING);
            fieldAddress = MBS_FIELD_INFO.createField("fieldAddress", MbsTypes.INTEGER);
        }

        public static MbsList<MbsFieldInfo> new_MbsFieldInfo_list(MbsIO data)
        {
            return new MbsList<MbsFieldInfo>(data, MBS_FIELD_INFO, new MbsFieldInfo(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_FIELD_INFO;
        }

        public MbsFieldInfo(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_FIELD_INFO.getSize()));
        }

        public string getName()
        {
            return data.readString(address + name.address);
        }
        public void setName(string _val)
        {
            data.writeString(address + name.address, _val);
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public int getFieldAddress()
        {
            return data.readInt(address + fieldAddress.address);
        }
        public void setFieldAddress(int _val)
        {
            data.writeInt(address + fieldAddress.address, _val);
        }
    }
}
