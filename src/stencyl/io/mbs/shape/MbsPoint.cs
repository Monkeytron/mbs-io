using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.shape
{
    public class MbsPoint : MbsObject
    {
        public static MbsField x;
        public static MbsField y;

        public static ComposedType MBS_POINT;

        static MbsPoint()
        {
            MBS_POINT = new ComposedType("MbsPoint");
            MBS_POINT.setInstantiator(data => new MbsPoint(data));

            x = MBS_POINT.createField("x", MbsTypes.FLOAT);
            y = MBS_POINT.createField("y", MbsTypes.FLOAT);
        }

        public static MbsList<MbsPoint> new_MbsPoint_list(MbsIO data)
        {
            return new MbsList<MbsPoint>(data, MBS_POINT, new MbsPoint(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_POINT;
        }

        public MbsPoint(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_POINT.getSize()));
        }

        public float getX()
        {
            return data.readFloat(address + x.address);
        }
        public void setX(float _val)
        {
            data.writeFloat(address + x.address, _val);
        }

        public float getY()
        {
            return data.readFloat(address + y.address);
        }
        public void setY(float _val)
        {
            data.writeFloat(address + y.address, _val);
        }
    }
}
