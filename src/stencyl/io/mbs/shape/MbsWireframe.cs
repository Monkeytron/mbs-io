using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.shape
{
    public class MbsWireframe : MbsPolygon
    {
        public static MbsField position;

        public static ComposedType MBS_WIREFRAME;
        static MbsWireframe()
        {
            MBS_WIREFRAME = new ComposedType("MbsWireframe");
            MBS_WIREFRAME.setInstantiator(data => new MbsWireframe(data));
            MBS_WIREFRAME.inherit(MbsPolygon.MBS_POLYGON);

            position = MBS_WIREFRAME.createField("position", MbsPoint.MBS_POINT);
        }

        public static MbsList<MbsWireframe> new_MbsWireframe_list(MbsIO data)
        {
            return new MbsList<MbsWireframe>(data, MBS_WIREFRAME, new MbsWireframe(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_WIREFRAME;
        }

        private MbsPoint _position;

        public MbsWireframe(MbsIO data) : base(data)
        {
            _position = new MbsPoint(data);
        }

        public override void allocateNew()
        {
            setAddress(data.allocate(MBS_WIREFRAME.getSize()));
        }

        public MbsPoint getPosition()
        {
            _position.setAddress(address + position.address);
            return _position;
        }
    }
}
