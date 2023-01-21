using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core
{
    public abstract class MbsObject
    {
        protected MbsIO data;
        protected int address;

        protected MbsObject(MbsIO data)
        {
            this.data = data;
        }

        public MbsIO GetMbs()
        {
            return data;
        }

        public virtual int getAddress()
        {
            return address;
        }

        public virtual void setAddress(int address)
        {
            this.address = address;
        }

        public virtual MbsType getMbsType()
        {
            throw new Exception("Must override getMbsType in MbsObject subclasses");
        }

        public override string ToString()
        {
            return $"Mbs object of type {getMbsType().getName()} at address {address}";

        }
    }
}
