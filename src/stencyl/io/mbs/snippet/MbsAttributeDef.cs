using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsAttributeDef : MbsObject
    {
        public static MbsField type;
        public static MbsField defaultValue;
        public static MbsField description;
        public static MbsField dropdown;
        public static MbsField fullname;
        public static MbsField hidden;
        public static MbsField id;
        public static MbsField name;
        public static MbsField order;

        public static ComposedType MBS_ATTRIBUTE_DEF;

        static MbsAttributeDef()
        {
            MBS_ATTRIBUTE_DEF = new ComposedType("MbsAttributeDef");
            MBS_ATTRIBUTE_DEF.setInstantiator(data => new MbsAttributeDef(data));

            type = MBS_ATTRIBUTE_DEF.createField("type", MbsTypes.STRING);
            defaultValue = MBS_ATTRIBUTE_DEF.createField("defaultValue", MbsTypes.DYNAMIC);
            description = MBS_ATTRIBUTE_DEF.createField("description", MbsTypes.STRING);
            dropdown = MBS_ATTRIBUTE_DEF.createField("dropdown", MbsTypes.STRING);
            fullname = MBS_ATTRIBUTE_DEF.createField("fullname", MbsTypes.STRING);
            hidden = MBS_ATTRIBUTE_DEF.createField("hidden", MbsTypes.BOOLEAN);
            id = MBS_ATTRIBUTE_DEF.createField("id", MbsTypes.INTEGER);
            name = MBS_ATTRIBUTE_DEF.createField("name", MbsTypes.STRING);
            order = MBS_ATTRIBUTE_DEF.createField("order", MbsTypes.INTEGER);
        }

        public static MbsList<MbsAttributeDef> new_MbsAttributeDef_list(MbsIO data)
        {
            return new MbsList<MbsAttributeDef>(data, MBS_ATTRIBUTE_DEF, new MbsAttributeDef(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_ATTRIBUTE_DEF;
        }

        public MbsAttributeDef(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_ATTRIBUTE_DEF.getSize()));
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public dynamic getDefaultValue()
        {
            return MbsDynamicHelper.readDynamic(data, address + defaultValue.address);
        }
        public void setDefaultValue(dynamic _val)
        {
            MbsDynamicHelper.writeDynamic(data, address + defaultValue.address, _val);
        }

        public string getDescription()
        {
            return data.readString(address + description.address);
        }
        public void setDescription(string _val)
        {
            data.writeString(address + description.address, _val);
        }

        public string getDropdown()
        {
            return data.readString(address + dropdown.address);
        }
        public void setDropdown(string _val)
        {
            data.writeString(address + dropdown.address, _val);
        }

        public string getFullname()
        {
            return data.readString(address + fullname.address);
        }
        public void setFullname(string _val)
        {
            data.writeString(address + fullname.address, _val);
        }

        public bool getHidden()
        {
            return data.readBool(address + hidden.address);
        }
        public void setHidden(bool _val)
        {
            data.writeBool(address + hidden.address, _val);
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public string getName()
        {
            return data.readString(address + name.address);
        }
        public void setName(string _val)
        {
            data.writeString(address + name.address, _val);
        }

        public int getOrder()
        {
            return data.readInt(address + order.address);
        }
        public void setOrder(int _val)
        {
            data.writeInt(address + order.address, _val);
        }
    }
}
