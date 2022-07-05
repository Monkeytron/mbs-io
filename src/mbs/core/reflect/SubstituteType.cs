using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haxe_mbs_translate.src.mbs.core.reflect
{
    public class SubstituteType:ComposedType
    {
        public string parentName;

        public SubstituteType(string name, string parentName, MbsField[] fields, int size):base(name)
        {
            this.parentName = parentName;
            this.fields = fields;
            this.size = size;
        }

        public void mapTypes(Dictionary<string, MbsType> typeMap)
        {
            parent = (ComposedType)typeMap[parentName];

            if(fields is not null)
            {
                for(int i = 0; i < fields.Length; i++)
                {
                    SubstituteField f = (SubstituteField)fields[i];
                    f.type = typeMap[f.typeName];
                }
            }
        }
    }
}
