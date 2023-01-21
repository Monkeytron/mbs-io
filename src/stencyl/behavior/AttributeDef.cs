using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class AttributeDef
    {
        public string type;
        public dynamic defaultValue;
        public string description;
        public string dropdown;
        public string fullname;
        public bool hidden;
        public int id;
        public string name;
        public int order;

        public AttributeDef(string type, dynamic defaultValue, string description, string dropdown, string fullname, bool hidden, int id, string name, int order)
        {
            this.type = type;
            this.defaultValue = defaultValue;
            this.description = description;
            this.dropdown = dropdown;
            this.fullname = fullname;
            this.hidden = hidden;
            this.id = id;
            this.name = name;
            this.order = order;
        }

        public static AttributeDef FromMbs(MbsAttributeDef mbsa)
        {
            dynamic trueDefault = mbsa.getDefaultValue(); 
            return new AttributeDef(mbsa.getType(), trueDefault, mbsa.getDescription(), mbsa.getDropdown(), mbsa.getFullname(), mbsa.getHidden(), mbsa.getId(), mbsa.getName(), mbsa.getOrder());
        }

        public override string ToString()
        {
            return $"AttributeDef {id} \"{name}\"  \"{fullname}\":\n\t{description}\n\tdropdown:{dropdown}, hidden:{hidden}, order:{order}, type:{type}\n\tdefault value:{defaultValue}";

        }

        public MbsAttributeDef WriteMbs(MbsAttributeDef mbsa)
        {
            mbsa.setType(type);
            mbsa.setDescription(description);
            mbsa.setDropdown(dropdown);
            mbsa.setFullname(fullname);
            mbsa.setHidden(hidden);
            mbsa.setId(id);
            mbsa.setName(name);
            mbsa.setOrder(order);

            mbsa.setDefaultValue(defaultValue);

            return mbsa;
        }
    }
}
