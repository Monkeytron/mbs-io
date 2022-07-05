using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class StencylAttribute
    {
        public int ID;
        public string type;
        public dynamic value;

        public StencylAttribute(int ID, string type, dynamic value)
        {
            this.ID = ID;
            this.type = type;
            this.value = value;
        }

        public static StencylAttribute FromMbs(MbsAttribute mbs)
        {
            switch (mbs.getType())
            {
                case "list":
                    {
                        MbsDynamicList listReader = mbs.getValue();
                        dynamic[] listRead = new dynamic[listReader.length()].Select(i => listReader.readObject()).ToArray();
                        return new StencylAttribute(mbs.getId(), mbs.getType(), listRead);
                    }
                case "map":
                    throw new Exception("Can't read map attribute.");
                default:
                    return new StencylAttribute(mbs.getId(), mbs.getType(), mbs.getValue());
            }
        }

        public override string ToString()
        {
            return $"Attribute {ID}:\n\tType:{type}\n\tValue:{value}";
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsAttribute WriteMbs(MbsAttribute mbs)
        {
            mbs.setId(ID);
            mbs.setType(type);
            if(type == "list")
            {
                if (value.Length != 0) throw new Exception("Can't write the list when the length is not 0 sadly.");
                else
                {
                    MbsDynamicList ds = new MbsDynamicList(mbs.GetMbs());
                    ds.allocateNew(0);
                    mbs.setValue(ds);
                }
            }
            else if (type == "map")
            {
                throw new Exception("Can't write map");
            }
            else
            {
                mbs.setValue(value);
            }

            return mbs;
        }
    }
}
