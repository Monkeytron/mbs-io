using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.layers;

namespace haxe_mbs_translate.src.stencyl.models.scene
{
    public class ColorBackground
    {
        public int color;

        public ColorBackground(int color)
        {
            this.color = color;
        }

        public static ColorBackground FromMbs(MbsColorBackground mbs)
        {
            return new ColorBackground(mbs.getColor());
        }
        public override string ToString()
        {
            return $"Color Background:\n\tColor:{color}";
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsColorBackground WriteMbs(MbsColorBackground mbs)
        {
            mbs.setColor(color);
            return mbs;
        }
    }
}
