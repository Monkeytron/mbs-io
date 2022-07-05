using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.physics
{
    public class MbsRegion : MbsObject
    {
        public static MbsField color;
        public static MbsField id;
        public static MbsField name;
        public static MbsField shape;
        public static MbsField x;
        public static MbsField y;

        public static ComposedType MBS_REGION;
        static MbsRegion()
        {
            MBS_REGION = new ComposedType("MbsRegion");
            MBS_REGION.setInstantiator(data => new MbsRegion(data));

            color = MBS_REGION.createField("color", MbsTypes.INTEGER);
            id = MBS_REGION.createField("id", MbsTypes.INTEGER);
            name = MBS_REGION.createField("name", MbsTypes.STRING);
            shape = MBS_REGION.createField("shape", MbsTypes.DYNAMIC);
            x = MBS_REGION.createField("x", MbsTypes.INTEGER);
            y = MBS_REGION.createField("y", MbsTypes.INTEGER);
        }

        public static MbsList<MbsRegion> new_MbsRegion_list(MbsIO data)
        {
            return new MbsList<MbsRegion>(data, MBS_REGION, new MbsRegion(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_REGION;
        }

        public MbsRegion(MbsIO data) : base(data)
        {

        }

        public virtual void allocateNew()
        {
            setAddress(data.allocate(MBS_REGION.getSize()));
        }

        public int getColor()
        {
            return data.readInt(address + color.address);
        }
        public void setColor(int _val)
        {
            data.writeInt(address + color.address, _val);
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public string getName()
        {
            return data.readString(address + name.address);
        }
        public void setName(string _val)
        {
            data.writeString(address + name.address, _val);
        }

        public dynamic getShape()
        {
            return MbsDynamicHelper.readDynamic(data, address + shape.address);
        }
        public void setShape(dynamic _val)
        {
            MbsDynamicHelper.writeDynamic(data, address + shape.address, _val);
        }

        public int getX()
        {
            return data.readInt(address + x.address);
        }
        public void setX(int _val)
        {
            data.writeInt(address + x.address, _val);
        }

        public int getY()
        {
            return data.readInt(address + y.address);
        }
        public void setY(int _val)
        {
            data.writeInt(address + y.address, _val);
        }
    }
}
