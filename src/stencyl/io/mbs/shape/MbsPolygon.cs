using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.shape
{
    public class MbsPolygon : MbsShape
    {
        public static MbsField points;

        public static ComposedType MBS_POLYGON;
        static MbsPolygon()
        {
            MBS_POLYGON = new ComposedType("MbsPolygon");
            MBS_POLYGON.setInstantiator(data => new MbsPolygon(data));
            MBS_POLYGON.inherit(MbsShape.MBS_SHAPE);

            points = MBS_POLYGON.createField("points", MbsTypes.LIST);
        }

        public static MbsList<MbsPolygon> new_MbsPolygon_list(MbsIO data)
        {
            return new MbsList<MbsPolygon>(data, MBS_POLYGON, new MbsPolygon(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_POLYGON;
        }

        private MbsList<MbsPoint> _points;

        public MbsPolygon(MbsIO data) : base(data)
        {
            _points = new MbsList<MbsPoint>(data, MbsPoint.MBS_POINT, new MbsPoint(data));
        }

        public override void allocateNew()
        {
            setAddress(data.allocate(MBS_POLYGON.getSize()));
        }

        public MbsList<MbsPoint> getPoints()
        {
            _points.setAddress(data.readInt(address + points.address));
            return _points;
        }
        public MbsList<MbsPoint> createPoints(int _length)
        {
            _points.allocateNew(_length);
            data.writeInt(address + points.address, _points.getAddress());
            return _points;
        }
    }
}
