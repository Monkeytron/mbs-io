using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsSnippetDef : MbsObject
    {
        public static MbsField attachedEvent;
        public static MbsField actorID;
        public static MbsField classname;
        public static MbsField description;
        public static MbsField design;
        public static MbsField drawOrder;
        public static MbsField id;
        public static MbsField name;
        public static MbsField packageName;
        public static MbsField sceneID;
        public static MbsField type;
        public static MbsField attributes;
        public static MbsField blocks;
        public static MbsField events;

        public static ComposedType MBS_SNIPPET_DEF;

        static MbsSnippetDef()
        {
            MBS_SNIPPET_DEF = new ComposedType("MbsSnippetDef");
            MBS_SNIPPET_DEF.setInstantiator(data => new MbsSnippetDef(data));

            attachedEvent = MBS_SNIPPET_DEF.createField("attachedEvent", MbsTypes.BOOLEAN);
            actorID = MBS_SNIPPET_DEF.createField("actorID", MbsTypes.INTEGER);
            classname = MBS_SNIPPET_DEF.createField("classname", MbsTypes.STRING);
            description = MBS_SNIPPET_DEF.createField("description", MbsTypes.STRING);
            design = MBS_SNIPPET_DEF.createField("design", MbsTypes.BOOLEAN);
            drawOrder = MBS_SNIPPET_DEF.createField("drawOrder", MbsTypes.INTEGER);
            id = MBS_SNIPPET_DEF.createField("id", MbsTypes.INTEGER);
            name = MBS_SNIPPET_DEF.createField("name", MbsTypes.STRING);
            packageName = MBS_SNIPPET_DEF.createField("packageName", MbsTypes.STRING);
            sceneID = MBS_SNIPPET_DEF.createField("sceneID", MbsTypes.INTEGER);
            type = MBS_SNIPPET_DEF.createField("type", MbsTypes.STRING);
            attributes = MBS_SNIPPET_DEF.createField("attributes", MbsTypes.LIST);
            blocks = MBS_SNIPPET_DEF.createField("blocks", MbsTypes.LIST);
            events = MBS_SNIPPET_DEF.createField("events", MbsTypes.LIST);
        }

        public static MbsList<MbsSnippetDef> new_MbsSnippetDef_list(MbsIO data)
        {
            return new MbsList<MbsSnippetDef>(data, MBS_SNIPPET_DEF, new MbsSnippetDef(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_SNIPPET_DEF;
        }

        private MbsList<MbsAttributeDef> _attributes;
        private MbsList<MbsBlock> _blocks;
        private MbsList<MbsEvent> _events;

        public MbsSnippetDef(MbsIO data) : base(data)
        {
            _attributes = MbsAttributeDef.new_MbsAttributeDef_list(data);
            _blocks = MbsBlock.new_MbsBlock_list(data);
            _events = MbsEvent.new_MbsEvent_list(data);
        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_SNIPPET_DEF.getSize()));
        }

        public bool getAttachedEvent()
        {
            return data.readBool(address + attachedEvent.address);
        }
        public void setAttachedEvent(bool _val)
        {
            data.writeBool(address + attachedEvent.address, _val);
        }

        public int getActorID()
        {
            return data.readInt(address + actorID.address);
        }
        public void setActorID(int _val)
        {
            data.writeInt(address + actorID.address, _val);
        }

        public string getClassname()
        {
            return data.readString(address + classname.address);
        }
        public void setClassname(string _val)
        {
            data.writeString(address + classname.address, _val);
        }

        public string getDescription()
        {
            return data.readString(address + description.address);
        }
        public void setDescription(string _val)
        {
            data.writeString(address + description.address, _val);
        }

        public bool getDesign()
        {
            return data.readBool(address + design.address);
        }
        public void setDesign(bool _val)
        {
            data.writeBool(address + design.address, _val);
        }

        public int getDrawOrder()
        {
            return data.readInt(address + drawOrder.address);
        }
        public void setDrawOrder(int _val)
        {
            data.writeInt(address + drawOrder.address, _val);
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

        public string getPackageName()
        {
            return data.readString(address + packageName.address);
        }
        public void setPackageName(string _val)
        {
            data.writeString(address + packageName.address, _val);
        }

        public int getSceneID()
        {
            return data.readInt(address + sceneID.address);
        }
        public void setSceneID(int _val)
        {
            data.writeInt(address + sceneID.address, _val);
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public MbsList<MbsAttributeDef> getAttributes()

        {
            _attributes.setAddress(data.readInt(address + attributes.address));
            return _attributes;
        }
        public MbsList<MbsAttributeDef> createAttributes(int _length)

        {
            _attributes.allocateNew(_length);
            data.writeInt(address + attributes.address, _attributes.getAddress());
            return _attributes;
        }

        public MbsList<MbsBlock> getBlocks()

        {
            _blocks.setAddress(data.readInt(address + blocks.address));
            return _blocks;
        }
        public MbsList<MbsBlock> createBlocks(int _length)

        {
            _blocks.allocateNew(_length);
            data.writeInt(address + blocks.address, _blocks.getAddress());
            return _blocks;
        }

        public MbsList<MbsEvent> getEvents()

        {
            _events.setAddress(data.readInt(address + events.address));
            return _events;
        }
        public MbsList<MbsEvent> createEvents(int _length)

        {
            _events.allocateNew(_length);
            data.writeInt(address + events.address, _events.getAddress());
            return _events;
        }
    }
}
