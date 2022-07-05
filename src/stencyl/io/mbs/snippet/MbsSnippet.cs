using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.stencyl.io.mbs.snippet
{
    public class MbsSnippet : MbsObject
    {
        public static MbsField enabled;
        public static MbsField id;
        public static MbsField properties;

        public static ComposedType MBS_SNIPPET;

        static MbsSnippet()
        {
            MBS_SNIPPET = new ComposedType("MbsSnippet");
            MBS_SNIPPET.setInstantiator(data => new MbsSnippet(data));

            enabled = MBS_SNIPPET.createField("enabled", MbsTypes.BOOLEAN);
            id = MBS_SNIPPET.createField("id", MbsTypes.INTEGER);
            properties = MBS_SNIPPET.createField("properties", MbsTypes.LIST);
        }

        public static MbsList<MbsSnippet> new_MbsSnippet_list(MbsIO data)
        {
            return new MbsList<MbsSnippet>(data, MBS_SNIPPET, new MbsSnippet(data));
        }

        public override MbsType getMbsType()
        {
            return MBS_SNIPPET;
        }

        private MbsList<MbsAttribute> _properties;

        public MbsSnippet(MbsIO data) : base(data)
        {
            _properties = MbsAttribute.new_MbsAttribute_list(data);
        }

        public void allocateNew()
        {
            setAddress(data.allocate(MBS_SNIPPET.getSize()));
        }

        public bool getEnabled()
        {
            return data.readBool(address + enabled.address);
        }
        public void setEnabled(bool _val)
        {
            data.writeBool(address + enabled.address, _val);
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public MbsList<MbsAttribute> getProperties()

        {
            _properties.setAddress(data.readInt(address + properties.address));
            return _properties;
        }
        public MbsList<MbsAttribute> createProperties(int _length)
        {
            _properties.allocateNew(_length);
            data.writeInt(address + properties.address, _properties.getAddress());
            return _properties;
        }
    }
}
