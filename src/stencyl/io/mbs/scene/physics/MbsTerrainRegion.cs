using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene.physics
{
    public class MbsTerrainRegion : MbsRegion
    {
        public static MbsField groupID;

        public static ComposedType MBS_TERRAIN_REGION;
        static MbsTerrainRegion()
        {
            MBS_TERRAIN_REGION = new ComposedType("MbsTerrainRegion");
            MBS_TERRAIN_REGION.setInstantiator(data => new MbsTerrainRegion(data));
            MBS_TERRAIN_REGION.inherit(MbsRegion.MBS_REGION);

            groupID = MBS_TERRAIN_REGION.createField("groupID", MbsTypes.INTEGER);
        }

        public static MbsList<MbsTerrainRegion> new_MbsTerrainRegion_list(MbsIO data)
        {
            return new MbsList<MbsTerrainRegion>(data, MBS_TERRAIN_REGION, new MbsTerrainRegion(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_TERRAIN_REGION;
        }

        public MbsTerrainRegion(MbsIO data) : base(data)
        {

        }

        public override void allocateNew()
        {
            setAddress(data.allocate(MBS_TERRAIN_REGION.getSize()));
        }

        public int getGroupID()
        {
            return data.readInt(address + groupID.address);
        }
        public void setGroupID(int _val)
        {
            data.writeInt(address + groupID.address, _val);
        }
    }
}
