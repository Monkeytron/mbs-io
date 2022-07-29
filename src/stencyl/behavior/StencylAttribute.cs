using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.core;
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
                        return new StencylAttribute(mbs.getId(), mbs.getType(), readList(mbs.getValue()));
                    }
                case "map":
                    {
                        return new StencylAttribute(mbs.getId(), mbs.getType(), readMap(mbs.getValue()));
                    }
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
                    mbs.setValue(writeList(value,mbs.GetMbs()));
                }
            }
            else if (type == "map")
            {
                mbs.setValue(writeMap(value, mbs.GetMbs()));
            }
            else
            {
                mbs.setValue(value);
            }

            return mbs;
        }

        public static dynamic[] readList(MbsDynamicList mbs)
        {
            if (mbs is null) return null;
            List<dynamic> list = new List<dynamic>();

            for(int i = 0; i < mbs.length(); i++)
            {
                dynamic d = mbs.readObject();
                if (d is MbsDynamicList) list.Add(readList(d));
                else if (d is MbsList<MbsMapElement>) list.Add(readMap(d));
                else list.Add(d);
            }

            return list.ToArray();
        }

        public static MbsDynamicList writeList(dynamic[] list, MbsIO mbs)
        {
            MbsDynamicList ds = new MbsDynamicList(mbs);

            ds.allocateNew(list.Length);

            foreach(dynamic d in list)
            {
                if (d is dynamic[])
                {
                    ds.writeObject(writeList(d, mbs));
                }
                else if (d is Dictionary<string, dynamic>)
                {
                    ds.writeObject(writeMap(d, mbs));
                }
                else ds.writeObject(d);
            }

            return ds;
        }

        public static MbsList<MbsMapElement> writeMap(Dictionary<string,dynamic> map, MbsIO mbs)
        {
            MbsList<MbsMapElement> mbsMap = MbsMapElement.new_MbsMapElement_list(mbs);

            foreach(string key in map.Keys)
            {
                dynamic value = map[key];

                MbsMapElement mme = mbsMap.getNextObject();
                mme.setKey(key);

                if (value is dynamic[])
                {
                    mme.setValue(writeList(value, mbs));
                }
                else if (value is Dictionary<string, dynamic>)
                {
                    mme.setValue(writeMap(value, mbs));
                }
                else mme.setValue(value);
            }

            return mbsMap;
        }

        public static Dictionary<string,dynamic> readMap(MbsList<MbsObject> mbs)
        {
            if (mbs is null) return null;

            if (mbs.type != MbsMapElement.MBS_MAP_ELEMENT) throw new Exception($"Must be MbsList<MbsMapElement> not MbsList<{mbs.type}>");

            Dictionary<string, dynamic> map = new Dictionary<string, dynamic>();

            for(int i = 0; i < mbs.length(); i++)
            {
                MbsMapElement mapElement = (MbsMapElement)mbs.getNextObject();
                dynamic val = mapElement.getValue();


                if(val is MbsDynamicList)
                {
                    map.Add(mapElement.getKey(), readList(val));
                }
                else if(val is MbsList<MbsMapElement>)
                {
                    map.Add(mapElement.getKey(),readMap(val));
                }

                else
                {
                    map.Add(mapElement.getKey(), val);
                }
            }

            return map;
        }
    }
}
