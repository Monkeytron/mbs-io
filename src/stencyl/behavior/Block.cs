using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class Block
    {
        public string type;
        public int id;
        public int blockId;

        public Block(string type, int id, int blockId)
        {
            this.type = type;
            this.id = id;
            this.blockId = blockId;
        }

        public static Block FromMbs(MbsBlock mbsb)
        {
            return new Block(mbsb.getType(), mbsb.getId(), mbsb.getBlockID());
        }
        public override string ToString()
        {
            return $"Block {id}, block#{blockId} : type {type}";
        }
        public MbsBlock WriteMbs(MbsBlock mbsb)
        {
            mbsb.setBlockID(blockId);
            mbsb.setId(id);
            mbsb.setType(type);
            return mbsb;
        }
    }
}
