using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class Behavior
    {
        public bool design;
        public bool isEvent;

        public int ID;
        public int actorID;
        public int sceneID;
        public int drawOrder;

        public string name;
        public string description;
        public string type;
        public string classname;
        public string packageName;

        public AttributeDef[] attributes;
        public Block[] blocks; public StencylEvent[] events;

        public Behavior(bool attachedEvent, int actorID, string classname, string description, bool design, int drawOrder, int id, string name, string packageName, int sceneID, string type, AttributeDef[] attributes, Block[] blocks, StencylEvent[] events)
        {
            this.isEvent = attachedEvent;
            this.design = design;

            this.ID = id;
            this.actorID = actorID;
            this.sceneID = sceneID;
            this.drawOrder = drawOrder;
            this.name = name;
            this.description = description;
            this.type = type;
            this.classname = classname;
            this.packageName = packageName;
            this.attributes = attributes; this.blocks = blocks; this.events = events;
        }

        public static Behavior FromMbs(MbsSnippetDef snip)
        {

            MbsList<MbsAttributeDef> attslist = snip.getAttributes();
            MbsList<MbsEvent> eventsList = snip.getEvents();
            MbsList<MbsBlock> blocksList = snip.getBlocks();



            return new Behavior(snip.getAttachedEvent(), snip.getActorID(), snip.getClassname(), snip.getDescription(), snip.getDesign(), snip.getDrawOrder(), snip.getId(), snip.getName(), snip.getPackageName(), snip.getSceneID(), snip.getType(), new AttributeDef[attslist.length()].Select(i => AttributeDef.FromMbs(attslist.getNextObject())).ToArray(), new Block[blocksList.length()].Select(i => Block.FromMbs(blocksList.getNextObject())).ToArray(), new StencylEvent[eventsList.length()].Select(i => StencylEvent.FromMbs(eventsList.getNextObject())).ToArray());
        }

        public override string ToString()
        {
            return $"Behavior {ID} \"{ name}\":\n\t{description}\n\tType {type}, class {classname} in package {packageName}\n\tdesign:{design}, isEvent:{isEvent}, actorID:{actorID}, sceneID:{sceneID}, draw order:{drawOrder}\n\t" +
                $"attributes: count = {attributes.Length}\n\t" + string.Join("\n\n", attributes.Select(i => i.ToString())).Replace("\n", "\n\t") +
                $"\n\nblocks: count = {blocks.Length}\n\t" + string.Join("\n\n", blocks.Select(i => i.ToString())).Replace("\n", "\n\t") +
                $"\n\nevents: count = {events.Length}\n\t" + string.Join("\n\n", events.Select(i => i.ToString())).Replace("\n", "\n\t");
        }
    }
}
