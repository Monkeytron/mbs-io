using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.core.reflect
{
    public class SubstituteField:MbsField
    {
        public string typeName;

        public SubstituteField(string name, string typeName, int address) : base(name, null, address)
        {
            this.typeName = typeName;
        }

        public override string ToString()
        {
            return $"MbsField [name={getName()}, typeName={typeName}, address={address}]";
        }
    }
}
