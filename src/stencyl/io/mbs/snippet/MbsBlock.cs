using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;


namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsBlock : MbsObject
    {
        public static MbsField type;
        public static MbsField id;
        public static MbsField blockID;

        public static ComposedType MBS_BLOCK;

        static MbsBlock()
        {
            MBS_BLOCK = new ComposedType("MbsBlock");
            MBS_BLOCK.setInstantiator(data => new MbsBlock(data));

            type = MBS_BLOCK.createField("type", MbsTypes.STRING);
            id = MBS_BLOCK.createField("id", MbsTypes.INTEGER);
            blockID = MBS_BLOCK.createField("blockID", MbsTypes.INTEGER);
        }

        public static MbsList<MbsBlock> new_MbsBlock_list(MbsIO data)
        {
            return new MbsList<MbsBlock>(data, MBS_BLOCK, new MbsBlock(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_BLOCK;
        }

        public MbsBlock(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_BLOCK.getSize()));
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public int getBlockID()
        {
            return data.readInt(address + blockID.address);
        }
        public void setBlockID(int _val)
        {
            data.writeInt(address + blockID.address, _val);
        }
    }
}
