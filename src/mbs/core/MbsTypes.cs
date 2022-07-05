using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace haxe_mbs_translate.src.mbs.core
{
    public class MbsTypes
    {
        public static MbsType BOOLEAN = new MbsType("boolean", 1);
        public static MbsType INTEGER = new MbsType("integer", 4);
        public static MbsType FLOAT = new MbsType("float", 4);
        public static MbsType STRING = new MbsType("string", 4);
        public static MbsType LIST = new MbsType("list", 4);
        public static MbsType DYNAMIC = new MbsType("dynamic", 8);
        public static MbsType NULL = new MbsType("null", 0);
    }
}
