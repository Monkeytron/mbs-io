using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.layers
{
    public class MbsImageBackground : MbsLayer
    {
        public static MbsField resourceID;
        public static MbsField customScroll;

        public static ComposedType MBS_IMAGE_BACKGROUND;

        static MbsImageBackground()
        {
            MBS_IMAGE_BACKGROUND = new ComposedType("MbsImageBackground");
            MBS_IMAGE_BACKGROUND.setInstantiator(data => new MbsImageBackground(data));
            MBS_IMAGE_BACKGROUND.inherit(MBS_LAYER);

            resourceID = MBS_IMAGE_BACKGROUND.createField("resourceID", MbsTypes.INTEGER);
            customScroll = MBS_IMAGE_BACKGROUND.createField("customScroll", MbsTypes.BOOLEAN);
        }

        public static MbsList<MbsImageBackground> new_MbsImageBackground_list(MbsIO data)
        {
            return new MbsList<MbsImageBackground>(data, MBS_IMAGE_BACKGROUND, new MbsImageBackground(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_IMAGE_BACKGROUND;
        }

        public MbsImageBackground(MbsIO data) : base(data)
        {

        }

        public override void allocateNew()
        {
            setAddress(data.allocate(MBS_IMAGE_BACKGROUND.getSize()));
        }

        public int getResourceID()
        {
            return data.readInt(address + resourceID.address);
        }
        public void setResourceID(int _val)
        {
            data.writeInt(address + resourceID.address, _val);
        }

        public bool getCustomScroll()
        {
            return data.readBool(address + customScroll.address);
        }
        public void setCustomScroll(bool _val)
        {
            data.writeBool(address + customScroll.address, _val);
        }
    }
}
