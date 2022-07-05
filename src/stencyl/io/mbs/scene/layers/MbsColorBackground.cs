using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.layers
{
    public class MbsColorBackground : MbsObject
    {
        public static MbsField color;

        public static ComposedType MBS_COLOR_BACKGROUND;

        static MbsColorBackground()
        {
            MBS_COLOR_BACKGROUND = new ComposedType("MbsColorBackground");
            MBS_COLOR_BACKGROUND.setInstantiator(data => new MbsColorBackground(data));

            color = MBS_COLOR_BACKGROUND.createField("color", MbsTypes.INTEGER);
        }

        public static MbsList<MbsColorBackground> new_MbsColorBackground_list(MbsIO data)
        {
            return new MbsList<MbsColorBackground>(data, MBS_COLOR_BACKGROUND, new MbsColorBackground(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_COLOR_BACKGROUND;
        }

        public MbsColorBackground(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_COLOR_BACKGROUND.getSize()));
        }

        public int getColor()
        {
            return data.readInt(address + color.address);
        }

        public void setColor(int _val)
        {
            data.writeInt(address + color.address, _val);
        }
    }
}
