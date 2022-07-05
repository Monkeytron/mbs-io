using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.behavior;
using haxe_mbs_translate.src.stencyl.io.mbs.scene;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.models.scene
{
    public class ActorInstance
    {
        public float angle;
        public int aid;
        public bool customized;
        public int groupID;
        public int id;
        public string name;
        public float scaleX;
        public float scaleY;
        public int x;
        public int y;
        public int z;
        public int orderInLayer;
        public BehaviorInstance[] behaviors;

        public ActorInstance(float angle, int aid, bool customized, int groupID, int id, string name, float scaleX, float scaleY, int x, int y, int z, int orderInLayer, BehaviorInstance[] behaviors)
        {
            this.angle = angle; this.aid = aid; this.customized = customized; this.groupID = groupID; this.id = id; this.name = name;
            this.scaleX = scaleX; this.scaleY = scaleY; this.x = x; this.y = y; this.z = z; this.orderInLayer = orderInLayer; this.behaviors = behaviors;
        }

        public static ActorInstance FromMbs(MbsActorInstance mbs)
        {
            MbsList<MbsSnippet> snippets = mbs.getSnippets();
            return new ActorInstance(mbs.getAngle(),
                mbs.getAid(),
                mbs.getCustomized(),
                mbs.getGroupID(),
                mbs.getId(),
                mbs.getName(),
                mbs.getScaleX(),
                mbs.getScaleY(),
                mbs.getX(),
                mbs.getY(),
                mbs.getZ(),
                mbs is MbsActorInstanceOld?-1:mbs.getOrderInLayer(),
                new BehaviorInstance[snippets.length()].Select(i => BehaviorInstance.FromMbs(snippets.getNextObject())).ToArray());
        }

        public override string ToString()
        {
            return ToString(false, false);
        }
        public string ToString(bool expandBehaviors, bool expandAttributes)
        {
            string output = $"Actor {aid} \"{name}\":";
            output += $"\n\tID:{id}, groupID:{groupID}";
            output += $"\n\tX:{x}, Y:{y}, Z:{z}, layer order:{orderInLayer}";
            output += $"\n\tScaleX:{scaleX}, scaleY:{scaleY}, angle:{angle}";
            output += $"\n\tBehaviors: count = {behaviors.Length}";
            if (expandBehaviors)
            {
                string behaviorsStr = string.Join('\n', behaviors.Select(i => i.ToString(expandAttributes)));
                output += $"\n\t\t{behaviorsStr.Replace("\n", "\n\t\t")}";
            }
            return output;
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsActorInstance WriteMbs(MbsActorInstance mbs)
        {
            mbs.setAngle(angle);
            mbs.setAid(aid);
            mbs.setCustomized(customized);
            mbs.setGroupID(groupID);
            mbs.setId(id);
            mbs.setName(name);
            mbs.setScaleX(scaleX);
            mbs.setScaleY(scaleY);
            mbs.setX(x);
            mbs.setY(y);
            mbs.setZ(z);
            if (mbs is not MbsActorInstanceOld) mbs.setOrderInLayer(orderInLayer);

            MbsList<MbsSnippet> list = mbs.createSnippets(behaviors.Length);

            foreach(BehaviorInstance b in behaviors)
            {
                b.WriteMbs(list.getNextObject());
            }

            return mbs;
        }
    }
}
