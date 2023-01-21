using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core.header;

namespace haxe_mbs_translate.src.mbs.core
{
    public class MbsTypedefSet
    {
        public static MbsType[] basicTypes;
        static MbsTypedefSet()
        {
            basicTypes = new MbsType[]
            {
                MbsTypes.BOOLEAN, // 0, 0x0
                MbsTypes.INTEGER, // 1, 0x1
                MbsTypes.FLOAT, // 2, 0x2
                MbsTypes.STRING, // 3, 0x3
                MbsTypes.LIST, // 4, 0x4
                MbsTypes.DYNAMIC, // 5,0x5
                MbsTypes.NULL, // 6, 0x6 (only in latest ver)
                MbsHeader.MBS_HEADER, // 7, 0x7 
                MbsTypeInfo.MBS_TYPE_INFO, // 8,0x8
                MbsFieldInfo.MBS_FIELD_INFO // 9,0x9
            };
        }

        public MbsType[] types;
        public Dictionary<MbsType, int> typeCodes;

        int hash;

        protected MbsTypedefSet()
        {
            types = basicTypes.Select(i => i).ToArray();
            typeCodes = new Dictionary<MbsType, int>();
            addTypes();

            int counter = 0;
            foreach(MbsType type in types)
            {
                if (!typeCodes.ContainsKey(type)) typeCodes.Add(type, counter++);
                else typeCodes[type] = counter++;
            }
        }

        // Allows TypedefSetHistory to combine different types and recreate how Typedefs was at a point in time.
        public MbsTypedefSet(int hash, params MbsType[] extraTypes)
        {
            types = basicTypes.Select(i => i).ToArray();
            addTypes();
            types = types.Concat(extraTypes).ToArray();
            typeCodes = new Dictionary<MbsType, int>();

            int counter = 0;

            foreach (MbsType type in types)
            {
                if (!typeCodes.ContainsKey(type)) typeCodes.Add(type, counter++);
                else typeCodes[type] = counter++;
            }

            this.hash = hash;
        }

        public MbsType[] getTypes()
        {
            return types;
        }

        public virtual void addTypes()
        {

        }

        public virtual int getHash()
        {
            return hash;
        }

        public int getTypecode(MbsType type)
        {
            return typeCodes[type];
        }

        public MbsType getType(int typecode)
        {
            return types[typecode];
        }
    }
}
