using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiscUtil.Conversion;

using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core
{
    public class MbsType
    {
        protected string name;
        protected int size;

        public MbsType(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public string getName()
        {
            return name;
        }

        public int getSize()
        {
            return size;
        }

        public override string ToString()
        {
            return $"MbsType [name = {name}]";
        }

        public virtual MbsObject createInstance(MbsIO data)
        {
            throw new Exception($"Can't create an instance of type [{name}]");
        }
    }
}
