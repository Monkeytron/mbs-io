using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.io
{
    public abstract class MbsIO
    {
        public abstract bool readBool(int address);

        public abstract float readFloat(int address);

        public abstract int readInt(int address);

        public abstract string readString(int address);

        public abstract void writeInt(int address, int value);

        public abstract void writeBool(int address, bool value);

        public abstract void writeFloat(int address, float value);

        public abstract void writeString(int address, string value);

        public abstract bool isReader();

        public abstract bool isWriter();

        public abstract int allocate(int size);

        public abstract void writeTypecode(int address, MbsType type);

        public abstract MbsType readTypecode(int address);
    }
}
