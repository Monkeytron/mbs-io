using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsListBase:MbsObject
    {
        public MbsType type;

        protected int elementAddress;
        protected int elementSize;

        private int _length;

        public MbsListBase(MbsIO data, MbsType type):base(data)
        {
            if(type is not null)
            {
                this.type = type;
                elementSize = type.getSize();
            }
        }

        public override MbsType getMbsType()
        {
            return MbsTypes.LIST;
        }

        public override void setAddress(int address)
        {
            base.setAddress(address);

            if (data.isReader())
            {
                if(address != 0)
                {
                    _length = data.readInt(address);
                    type = data.readTypecode(address + MbsTypes.INTEGER.getSize());

                    elementSize = type.getSize();
                    elementAddress = address + MbsTypes.INTEGER.getSize() * 2;
                }
                else
                {
                    type = null;
                    _length = 0;
                    elementSize = 0;
                    elementAddress = 0;
                }
            }
        }

        public int allocateNew(int length)
        {
            if (data.isWriter())
            {
                _length = length;

                address = data.allocate(MbsTypes.INTEGER.getSize() * 2 + elementSize * length);
                data.writeInt(address, length);
                data.writeTypecode(address + MbsTypes.INTEGER.getSize(), type);
                elementAddress = address + MbsTypes.INTEGER.getSize() * 2;

                return address;
            }
            else
            {
                throw new Exception("Can't allocate new objects when reading");
            }
        }
        public int length()
        {
            return _length;
        }
    }

    public class MbsBoolList : MbsListBase
    {
        public MbsBoolList(MbsIO data) : base(data, MbsTypes.BOOLEAN)
        {

        }

        public bool readBool()
        {
            bool b = data.readBool(elementAddress);
            elementAddress += elementSize;
            return b;
        }
        public void writeBool(bool value)
        {
            data.writeBool(elementAddress, value);
            elementAddress += elementSize;
        }
    }

    public class MbsFloatList : MbsListBase
    {
        public MbsFloatList(MbsIO data):base(data, MbsTypes.FLOAT)
        {

        }

        public float readFloat()
        {
            float f = data.readFloat(elementAddress);
            elementAddress += elementSize;
            return f;
        }
        public void writeFloat(float value)
        {
            data.writeFloat(elementAddress, value);
            elementAddress += elementSize;
        }
    }

    public class MbsIntList : MbsListBase
    {
        public MbsIntList(MbsIO data):base(data, MbsTypes.INTEGER)
        {

        }

        public int readInt()
        {
            int i = data.readInt(elementAddress);
            elementAddress += elementSize;
            return i;
        }
        public void writeInt(int value)
        {
            data.writeInt(elementAddress, value);
            elementAddress += elementSize;
        }
    }

    public class MbsStringList : MbsListBase
    {
        public MbsStringList(MbsIO data) : base(data, MbsTypes.STRING)
        {

        }

        public string readString()
        {
            string s = data.readString(elementAddress);
            elementAddress += elementSize;
            return s;
        }
        public void writeString(string value)
        {
            data.writeString(elementAddress, value);
            elementAddress += elementSize;
        }
    }

    public class MbsDynamicList : MbsListBase
    {
        public MbsDynamicList(MbsIO data):base(data, MbsTypes.DYNAMIC)
        {

        }

        public dynamic readObject()
        {
            dynamic obj = MbsDynamicHelper.readDynamic(data, elementAddress);
            elementAddress += elementSize;
            return obj;
        }
        public dynamic readObjectUsingPool(Dictionary<MbsType,MbsObject> pool)
        {
            dynamic obj = MbsDynamicHelper.readDynamicUsingPool(data, elementAddress, pool);
            elementAddress += elementSize;
            return obj;
        }
        public void writeObject(dynamic o)
        {
            MbsDynamicHelper.writeDynamic(data, elementAddress, o);
            elementAddress += elementSize;
        }
    }
}
