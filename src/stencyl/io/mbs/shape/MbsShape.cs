using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.shape
{
    public class MbsShape : MbsObject
    {
        public static ComposedType MBS_SHAPE;

        static MbsShape()
        {
            MBS_SHAPE = new ComposedType("MbsShape");
            MBS_SHAPE.setInstantiator(data => new MbsShape(data));
        }

        public static MbsList<MbsShape> new_MbsShape_list(MbsIO data)
        {
            return new MbsList<MbsShape>(data, MBS_SHAPE, new MbsShape(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_SHAPE;
        }

        public MbsShape(MbsIO data):base(data)
        {

        }

        public virtual void allocateNew()
        {
            setAddress(data.allocate(MBS_SHAPE.getSize()));
        }
    }
}
