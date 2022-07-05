using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haxe_mbs_translate.src.mbs.core
{
    public class MbsField
    {
        public string name;
        public MbsType type;
        public int address;

        public MbsField(string name, MbsType type, int address)
        {
            this.name = name;
            this.type = type;
            this.address = address;
        }

        public string getName()
        {
            return name;
        }

        public MbsType getType()
        {
            return type;
        }

        public int getAddress()
        {
            return address;
        }
    }
}
