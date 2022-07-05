using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsGenericObject : MbsObject
    {
        public MbsType type;

        public MbsGenericObject(MbsIO data, MbsType type) : base(data)
        {
            this.type = type;
        }

        public int allocateNew()
        {
            return address = data.allocate(type.getSize());
        }

        public bool readBool(MbsField field)
        {
            return data.readBool(address + field.address);
        }
        public void writeBool(MbsField field, bool value)
        {
            data.writeBool(address + field.address, value);
        }

        public float readFloat(MbsField field)
        {
            return data.readFloat(address + field.address);
        }
        public void writeFloat(MbsField field, float value)
        {
            data.writeFloat(address + field.address, value);
        }

        public int readInt(MbsField field)
        {
            return data.readInt(address + field.address);
        }
        public void writeInt(MbsField field, int value)
        {
            data.writeInt(address + field.address, value);
        }

        public string readString(MbsField field)
        {
            return data.readString(address + field.address);
        }
        public void writeString(MbsField field, string value)
        {
            data.writeString(address + field.address, value);
        }

        /// <summary>
        /// For embedded objects
        /// </summary>
        public void prepareObject(MbsField field, MbsObject helper)
        {
            helper.setAddress(address + field.address);
        }
        /// <summary>
        /// For linked objects
        /// </summary>
        public void readObject(MbsField field, MbsObject helper)
        {
            helper.setAddress(data.readInt(address + field.address));
        }

        public override MbsType getMbsType()
        {
            return type;
        }
    }
}
