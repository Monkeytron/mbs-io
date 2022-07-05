using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsEvent : MbsObject
    {
        public static MbsField displayName;
        public static MbsField enabled;
        public static MbsField id;
        public static MbsField name;
        public static MbsField order;
        public static MbsField repeats;

        public static ComposedType MBS_EVENT;

        static MbsEvent()
        {
            MBS_EVENT = new ComposedType("MbsEvent");
            MBS_EVENT.setInstantiator(data => new MbsEvent(data));

            displayName = MBS_EVENT.createField("displayName", MbsTypes.STRING);
            enabled = MBS_EVENT.createField("enabled", MbsTypes.BOOLEAN);
            id = MBS_EVENT.createField("id", MbsTypes.INTEGER);
            name = MBS_EVENT.createField("name", MbsTypes.STRING);
            order = MBS_EVENT.createField("order", MbsTypes.INTEGER);
            repeats = MBS_EVENT.createField("repeats", MbsTypes.BOOLEAN);
        }

        public static MbsList<MbsEvent> new_MbsEvent_list(MbsIO data)
        {
            return new MbsList<MbsEvent>(data, MBS_EVENT, new MbsEvent(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_EVENT;
        }

        public MbsEvent(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_EVENT.getSize()));
        }

        public string getDisplayName()
        {
            return data.readString(address + displayName.address);
        }
        public void setDisplayName(string _val)
        {
            data.writeString(address + displayName.address, _val);
        }

        public bool getEnabled()
        {
            return data.readBool(address + enabled.address);
        }
        public void setEnabled(bool _val)
        {
            data.writeBool(address + enabled.address, _val);
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

        public bool getRepeats()
        {
            return data.readBool(address + repeats.address);
        }
        public void setRepeats(bool _val)
        {
            data.writeBool(address + repeats.address, _val);
        }
    }
}
