using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.layers;

namespace haxe_mbs_translate.src.stencyl.models.scene
{
    public class Layer
    {
        public int id;
        public string name;
        public int order;
        public int opacity;
        public string blendmode;
        public float scrollFactorX;
        public float scrollFactorY;
        public bool visible;
        public bool locked;

        public Layer(int id, string name, int order, int opacity, string blendmode, float scrollFactorX, float scrollFactorY, bool visible, bool locked)
        {
            this.id = id;
            this.name = name;
            this.order = order;
            this.opacity = opacity;
            this.blendmode = blendmode;
            this.scrollFactorX = scrollFactorX;
            this.scrollFactorY = scrollFactorY;
            this.visible = visible;
            this.locked = locked;
        }

        public static Layer FromMbsGeneral(dynamic mbs)
        {
            if (mbs is MbsInteractiveLayer) return InteractiveLayer.FromMbs((MbsInteractiveLayer)mbs);
            else if (mbs is MbsImageBackground) return ImageBackground.FromMbs((MbsImageBackground)mbs);
            else if (mbs is MbsLayer) return new Layer(mbs.getId(), mbs.getName(), mbs.getOrder(), mbs.getOpacity(), mbs.getBlendmode(), mbs.getScrollFactorX(), mbs.getScrollFactorY(), mbs.getVisible(), mbs.getLocked());
            else if (mbs is MbsObject) throw new Exception($"Invalid type of Mbs : {mbs.getMbsType()}");
            else throw new Exception($"{mbs} is not an MbsObject so it can't be read.");
        }
        public override string ToString()
        {
            string output = $"Layer {id} \"{name}\":";
            output += $"\n\tType:Layer";
            output += $"\n\tOrder:{order}, Opacity:{opacity}, Blendmode:{blendmode}";
            output += $"\n\tScroll Factors - X:{scrollFactorX},Y:{scrollFactorY}";
            output += $"\n\tVisible:{visible}, Locked:{locked}";
            return output;
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public virtual MbsLayer WriteMbs(MbsLayer mbs)
        {
            mbs.setId(id);
            mbs.setName(name);
            mbs.setOrder(order);
            mbs.setOpacity(opacity);
            mbs.setBlendmode(blendmode);
            mbs.setScrollFactorX(scrollFactorX);
            mbs.setScrollFactorY(scrollFactorY);
            mbs.setVisible(visible);
            mbs.setLocked(locked);

            return mbs;
        }
    }

    public class InteractiveLayer : Layer
    {
        public int color;

        public InteractiveLayer(int id, string name, int order, int opacity, string blendmode, float scrollFactorX, float scrollFactorY, bool visible, bool locked, int color):base(id, name, order, opacity, blendmode, scrollFactorX, scrollFactorY, visible, locked)
        {
            this.color = color;
        }

        public static InteractiveLayer FromMbs(MbsInteractiveLayer mbs)
        {
            return new InteractiveLayer(mbs.getId(), mbs.getName(), mbs.getOrder(), mbs.getOpacity(), mbs.getBlendmode(), mbs.getScrollFactorX(), mbs.getScrollFactorY(), mbs.getVisible(), mbs.getLocked(), mbs.getColor());
        }

        public override string ToString()
        {
            return base.ToString().Replace("Type:Layer","Type:InteractiveLayer")+$"\n\tColor:{color}";
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public override MbsLayer WriteMbs(MbsLayer mbs)
        {
            MbsInteractiveLayer mbs1 = (MbsInteractiveLayer)base.WriteMbs(mbs);
            mbs1.setColor(color);
            return mbs1;
        }
    }

    public class ImageBackground : Layer
    {
        public int resourceID;
        public bool customScroll;

        public ImageBackground(int id, string name, int order, int opacity, string blendmode, float scrollFactorX, float scrollFactorY, bool visible, bool locked, int resourceID, bool customScroll) : base(id, name, order, opacity, blendmode, scrollFactorX, scrollFactorY, visible, locked)
        {
            this.resourceID = resourceID;
            this.customScroll = customScroll;
        }
    
        public static ImageBackground FromMbs(MbsImageBackground mbs)
        {
            return new ImageBackground(mbs.getId(), mbs.getName(), mbs.getOrder(), mbs.getOpacity(), mbs.getBlendmode(), mbs.getScrollFactorX(), mbs.getScrollFactorY(), mbs.getVisible(), mbs.getLocked(), mbs.getResourceID(), mbs.getCustomScroll());
        }
        public override string ToString()
        {
            return base.ToString().Replace("Type:Layer", "Type:ImageBackground") + $"\n\tresourceID:{resourceID}, customScroll:{customScroll}";
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public override MbsLayer WriteMbs(MbsLayer mbs)
        {
            MbsImageBackground mbs1 = (MbsImageBackground)base.WriteMbs(mbs);
            mbs1.setResourceID(resourceID);
            mbs1.setCustomScroll(customScroll);
            return mbs1;
        }
    }
}
