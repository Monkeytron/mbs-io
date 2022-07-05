using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.layers
{
    public class MbsLayer : MbsObject
    {
        public static MbsField id;
        public static MbsField name;
        public static MbsField order;
        public static MbsField opacity;
        public static MbsField blendmode;
        public static MbsField scrollFactorX;
        public static MbsField scrollFactorY;
        public static MbsField visible;
        public static MbsField locked;

        public static ComposedType MBS_LAYER;

        static MbsLayer()
        {
            MBS_LAYER = new ComposedType("MbsLayer");
            MBS_LAYER.setInstantiator(data => new MbsLayer(data));

            id = MBS_LAYER.createField("id", MbsTypes.INTEGER);
            name = MBS_LAYER.createField("name", MbsTypes.STRING);
            order = MBS_LAYER.createField("order", MbsTypes.INTEGER);
            opacity = MBS_LAYER.createField("opacity", MbsTypes.INTEGER);
            blendmode = MBS_LAYER.createField("blendmode", MbsTypes.STRING);
            scrollFactorX = MBS_LAYER.createField("scrollFactorX", MbsTypes.FLOAT);
            scrollFactorY = MBS_LAYER.createField("scrollFactorY", MbsTypes.FLOAT);
            visible = MBS_LAYER.createField("visible", MbsTypes.BOOLEAN);
            locked = MBS_LAYER.createField("locked", MbsTypes.BOOLEAN);
        }

        public static MbsList<MbsLayer> new_MbsLayer_list(MbsIO data)
        {
            return new MbsList<MbsLayer>(data, MBS_LAYER, new MbsLayer(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_LAYER;
        }

        public MbsLayer(MbsIO data) : base(data)
        {

        }

        public virtual void allocateNew()
        {
            setAddress(data.allocate(MBS_LAYER.getSize()));
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

        public int getOrder()
        {
            return data.readInt(address + order.address);
        }
        public void setOrder(int _val)
        {
            data.writeInt(address + order.address, _val);
        }

        public int getOpacity()
        {
            return data.readInt(address + opacity.address);
        }
        public void setOpacity(int _val)
        {
            data.writeInt(address + opacity.address, _val);
        }

        public string getBlendmode()
        {
            return data.readString(address + blendmode.address);
        }
        public void setBlendmode(string _val)
        {
            data.writeString(address + blendmode.address, _val);
        }

        public float getScrollFactorX()
        {
            return data.readFloat(address + scrollFactorX.address);
        }
        public void setScrollFactorX(float _val)
        {
            data.writeFloat(address + scrollFactorX.address, _val);
        }

        public float getScrollFactorY()
        {
            return data.readFloat(address + scrollFactorY.address);
        }
        public void setScrollFactorY(float _val)
        {
            data.writeFloat(address + scrollFactorY.address, _val);
        }

        public bool getVisible()
        {
            return data.readBool(address + visible.address);
        }
        public void setVisible(bool _val)
        {
            data.writeBool(address + visible.address, _val);
        }

        public bool getLocked()
        {
            return data.readBool(address + locked.address);
        }
        public void setLocked(bool _val)
        {
            data.writeBool(address + locked.address, _val);
        }
    }
}
