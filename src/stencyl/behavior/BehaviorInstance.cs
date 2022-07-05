using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class BehaviorInstance
    {
        public bool enabled;
        public int id;
        public StencylAttribute[] properties;

        public BehaviorInstance(bool enabled, int id, StencylAttribute[] properties)
        {
            this.enabled = enabled;
            this.id = id;
            this.properties = properties;
        }

        public static BehaviorInstance FromMbs(MbsSnippet mbs)
        {
            MbsList<MbsAttribute> properties = mbs.getProperties();

            return new BehaviorInstance(mbs.getEnabled(), mbs.getId(), new StencylAttribute[properties.length()].Select(i => StencylAttribute.FromMbs(properties.getNextObject())).ToArray());
        }

        public override string ToString()
        {
            return $"Snippet {id}";
        }

        public string ToString(bool expandFully)
        {
            string output = $"Snippet {id}:";
            output += $"\n\tEnabled:{enabled}";
            output += $"\n\tProperties: Count = {properties.Length}";
            if (expandFully)
            {
                string propertiesStr = string.Join('\n',properties.Select(i => i.ToString()));
                output += $"\n\t\t{propertiesStr.Replace("\n", "\n\t\t")}";
            }
            return output;
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsSnippet WriteMbs(MbsSnippet mbs)
        {
            mbs.setEnabled(enabled);
            mbs.setId(id);
            MbsList<MbsAttribute> list = mbs.createProperties(properties.Length);
            foreach (StencylAttribute att in properties) att.WriteMbs(list.getNextObject());

            return mbs;
        }
    }
}
