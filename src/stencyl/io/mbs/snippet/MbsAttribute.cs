using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsAttribute:MbsObject
    {
        public static MbsField id;
        public static MbsField type;
        public static MbsField value;

        public static ComposedType MBS_ATTRIBUTE;

        static MbsAttribute()
        {
            MBS_ATTRIBUTE = new ComposedType("MbsAttribute");
            MBS_ATTRIBUTE.setInstantiator(data => new MbsAttribute(data));

            id = MBS_ATTRIBUTE.createField("id", MbsTypes.INTEGER);
            type = MBS_ATTRIBUTE.createField("type", MbsTypes.STRING);
            value = MBS_ATTRIBUTE.createField("value", MbsTypes.DYNAMIC);
        }

        public static MbsList<MbsAttribute> new_MbsAttribute_list(MbsIO data)
        {
            return new MbsList<MbsAttribute>(data, MBS_ATTRIBUTE, new MbsAttribute(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_ATTRIBUTE;
        }
        public MbsAttribute(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_ATTRIBUTE.getSize()));
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public dynamic getValue()
        {
            return MbsDynamicHelper.readDynamic(data, address + value.address);
        }
        public void setValue(dynamic _val)
        {
            MbsDynamicHelper.writeDynamic(data, address + value.address, _val);
        }
    }
}
