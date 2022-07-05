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
                MbsTypes.BOOLEAN,
                MbsTypes.INTEGER,
                MbsTypes.FLOAT,
                MbsTypes.STRING,
                MbsTypes.LIST,
                MbsTypes.DYNAMIC,
                MbsTypes.NULL,
                MbsHeader.MBS_HEADER,
                MbsTypeInfo.MBS_TYPE_INFO,
                MbsFieldInfo.MBS_FIELD_INFO
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
