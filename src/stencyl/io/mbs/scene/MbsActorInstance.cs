using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene
{
    /// <summary>
    /// In layer actors and later
    /// </summary>
    public class MbsActorInstance : MbsObject
    {
        public static MbsField angle;
        public static MbsField aid;
        public static MbsField customized;
        public static MbsField groupID;
        public static MbsField id;
        public static MbsField name;
        public static MbsField scaleX;
        public static MbsField scaleY;
        public static MbsField x;
        public static MbsField y;
        public static MbsField z;
        public static MbsField orderInLayer;
        public static MbsField snippets;

        public static ComposedType MBS_ACTOR_INSTANCE;

        static MbsActorInstance()
        {
            MBS_ACTOR_INSTANCE = new ComposedType("MbsActorInstance");
            MBS_ACTOR_INSTANCE.setInstantiator(data => new MbsActorInstance(data));

            angle = MBS_ACTOR_INSTANCE.createField("angle", MbsTypes.FLOAT);
            aid = MBS_ACTOR_INSTANCE.createField("aid", MbsTypes.INTEGER);
            customized = MBS_ACTOR_INSTANCE.createField("customized", MbsTypes.BOOLEAN);
            groupID = MBS_ACTOR_INSTANCE.createField("groupID", MbsTypes.INTEGER);
            id = MBS_ACTOR_INSTANCE.createField("id", MbsTypes.INTEGER);
            name = MBS_ACTOR_INSTANCE.createField("name", MbsTypes.STRING);
            scaleX = MBS_ACTOR_INSTANCE.createField("scaleX", MbsTypes.FLOAT);
            scaleY = MBS_ACTOR_INSTANCE.createField("scaleY", MbsTypes.FLOAT);
            x = MBS_ACTOR_INSTANCE.createField("x", MbsTypes.INTEGER);
            y = MBS_ACTOR_INSTANCE.createField("y", MbsTypes.INTEGER);
            z = MBS_ACTOR_INSTANCE.createField("z", MbsTypes.INTEGER);
            orderInLayer = MBS_ACTOR_INSTANCE.createField("orderInLayer", MbsTypes.INTEGER);
            snippets = MBS_ACTOR_INSTANCE.createField("snippets", MbsTypes.LIST);
        }

        public static MbsList<MbsActorInstance> new_MbsActorInstance_list(MbsIO data)
        {
            return new MbsList<MbsActorInstance>(data, MBS_ACTOR_INSTANCE, new MbsActorInstance(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_ACTOR_INSTANCE;
        }

        private MbsList<MbsSnippet> _snippets;

        public MbsActorInstance(MbsIO data) : base(data)
        {
            _snippets = MbsSnippet.new_MbsSnippet_list(data);
        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_ACTOR_INSTANCE.getSize()));
        }

        public float getAngle()
        {
            return data.readFloat(address + angle.address);
        }
        public void setAngle(float _val)
        {
            data.writeFloat(address + angle.address, _val);
        }

        public int getAid()
        {
            return data.readInt(address + aid.address);
        }
        public void setAid(int _val)
        {
            data.writeInt(address + aid.address, _val);
        }

        public bool getCustomized()
        {
            return data.readBool(address + customized.address);
        }
        public void setCustomized(bool _val)
        {
            data.writeBool(address + customized.address, _val);
        }

        public int getGroupID()
        {
            return data.readInt(address + groupID.address);
        }
        public void setGroupID(int _val)
        {
            data.writeInt(address + groupID.address, _val);
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

        public float getScaleX()
        {
            return data.readFloat(address + scaleX.address);
        }
        public void setScaleX(float _val)
        {
            data.writeFloat(address + scaleX.address, _val);
        }

        public float getScaleY()
        {
            return data.readFloat(address + scaleY.address);
        }
        public void setScaleY(float _val)
        {
            data.writeFloat(address + scaleY.address, _val);
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

        public int getZ()
        {
            return data.readInt(address + z.address);
        }
        public void setZ(int _val)
        {
            data.writeInt(address + z.address, _val);
        }

        public virtual int getOrderInLayer()
        {
            return data.readInt(address + orderInLayer.address);
        }
        public virtual void setOrderInLayer(int _val)
        {
            data.writeInt(address + orderInLayer.address, _val);
        }

        public virtual MbsList<MbsSnippet> getSnippets()
        {
            _snippets.setAddress(data.readInt(address + snippets.address));
            return _snippets;
        }
        public virtual MbsList<MbsSnippet> createSnippets(int _length)
        {
            _snippets.allocateNew(_length);
            data.writeInt(address + snippets.address, _snippets.getAddress());
            return _snippets;
        }
    }


    /// <summary>
    /// Pre - In layer actors
    /// </summary>
    public class MbsActorInstanceOld : MbsActorInstance
    {
        public static MbsField newSnippets;

        public static ComposedType MBS_ACTOR_INSTANCE_OLD;

        static MbsActorInstanceOld()
        {
            MBS_ACTOR_INSTANCE_OLD = new ComposedType("MbsActorInstanceOld");
            MBS_ACTOR_INSTANCE_OLD.setInstantiator(data => new MbsActorInstanceOld(data));

            angle = MBS_ACTOR_INSTANCE_OLD.createField("angle", MbsTypes.FLOAT);
            aid = MBS_ACTOR_INSTANCE_OLD.createField("aid", MbsTypes.INTEGER);
            customized = MBS_ACTOR_INSTANCE_OLD.createField("customized", MbsTypes.BOOLEAN);
            groupID = MBS_ACTOR_INSTANCE_OLD.createField("groupID", MbsTypes.INTEGER);
            id = MBS_ACTOR_INSTANCE_OLD.createField("id", MbsTypes.INTEGER);
            name = MBS_ACTOR_INSTANCE_OLD.createField("name", MbsTypes.STRING);
            scaleX = MBS_ACTOR_INSTANCE_OLD.createField("scaleX", MbsTypes.FLOAT);
            scaleY = MBS_ACTOR_INSTANCE_OLD.createField("scaleY", MbsTypes.FLOAT);
            x = MBS_ACTOR_INSTANCE_OLD.createField("x", MbsTypes.INTEGER);
            y = MBS_ACTOR_INSTANCE_OLD.createField("y", MbsTypes.INTEGER);
            z = MBS_ACTOR_INSTANCE_OLD.createField("z", MbsTypes.INTEGER);
            newSnippets = MBS_ACTOR_INSTANCE_OLD.createField("snippets", MbsTypes.LIST);
        }

        public static MbsList<MbsActorInstanceOld> new_MbsActorInstanceOld_list(MbsIO data)
        {
            return new MbsList<MbsActorInstanceOld>(data, MBS_ACTOR_INSTANCE_OLD, new MbsActorInstanceOld(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_ACTOR_INSTANCE_OLD;
        }

        private MbsList<MbsSnippet> _newSnippets;

        public MbsActorInstanceOld(MbsIO data) : base(data)
        {
            _newSnippets = MbsSnippet.new_MbsSnippet_list(data);
        }

        public override int getOrderInLayer()
        {
            throw new NotImplementedException("in-layer ordering did not exist in this version!");
        }
        public override void setOrderInLayer(int _val)
        {
            throw new NotImplementedException("in-layer ordering did not exist in this version!");
        }

        public override MbsList<MbsSnippet> getSnippets()
        {
            _newSnippets.setAddress(data.readInt(address + newSnippets.address));
            return _newSnippets;
        }
        public override MbsList<MbsSnippet> createSnippets(int _length)
        {
            _newSnippets.allocateNew(_length);
            data.writeInt(address + newSnippets.address, _newSnippets.getAddress());
            return _newSnippets;
        }
    }
}
