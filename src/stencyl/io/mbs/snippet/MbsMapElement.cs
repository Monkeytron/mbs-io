using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsMapElement : MbsObject
    {
        public static MbsField key;
        public static MbsField value;

        public static ComposedType MBS_MAP_ELEMENT;

        static MbsMapElement()
        {
            MBS_MAP_ELEMENT = new ComposedType("MbsMapElement");
            MBS_MAP_ELEMENT.setInstantiator(data => new MbsMapElement(data));

            key = MBS_MAP_ELEMENT.createField("key", MbsTypes.STRING);
            value = MBS_MAP_ELEMENT.createField("value", MbsTypes.DYNAMIC);
        }

        public static MbsList<MbsMapElement> new_MbsMapElement_list(MbsIO data)
        {
            return new MbsList<MbsMapElement>(data, MBS_MAP_ELEMENT, new MbsMapElement(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_MAP_ELEMENT;
        }

        public MbsMapElement(MbsIO data) : base(data)
        {

        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_MAP_ELEMENT.getSize()));
        }

        public string getKey()
	{
            return data.readString(address + key.address);
        }
        public void setKey(string _val)
        {
            data.writeString(address + key.address, _val);
        }

        public dynamic getValue() 
        {
            return MbsDynamicHelper.readDynamic(data, address + value.address);
        }
        public void setValue(dynamic _val)
        {
            MbsDynamicHelper.writeDynamic(data, address + value.address, _val);
        }
    }
}
