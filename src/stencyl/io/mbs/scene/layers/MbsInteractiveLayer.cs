using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.layers
{
    public class MbsInteractiveLayer : MbsLayer
    {
        public static MbsField color;

        public static ComposedType MBS_INTERACTIVE_LAYER;

        static MbsInteractiveLayer()
        {
            MBS_INTERACTIVE_LAYER = new ComposedType("MbsInteractiveLayer");
            MBS_INTERACTIVE_LAYER.setInstantiator(data => new MbsInteractiveLayer(data));
            MBS_INTERACTIVE_LAYER.inherit(MBS_LAYER);

            color = MBS_INTERACTIVE_LAYER.createField("color", MbsTypes.INTEGER);
        }

        public static MbsList<MbsInteractiveLayer> new_MbsInteractiveLayer_list(MbsIO data)
        {
            return new MbsList<MbsInteractiveLayer>(data, MBS_INTERACTIVE_LAYER, new MbsInteractiveLayer(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_INTERACTIVE_LAYER;
        }

        public MbsInteractiveLayer(MbsIO data) : base(data)
        {

        }

        public override void allocateNew()
        {
            setAddress(data.allocate(MBS_INTERACTIVE_LAYER.getSize()));
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
