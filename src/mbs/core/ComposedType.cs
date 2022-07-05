using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.io;

namespace haxe_mbs_translate.src.mbs.core
{
    public class ComposedType : MbsType
    {
        protected ComposedType parent;
        protected MbsField[] fields;

        public ComposedType(string name) : base(name, 0)
        {
            fields = new MbsField[0];
        }

        public void inherit(ComposedType type)
        {
            parent = type;
            size = type.getSize();
        }

        public MbsField createField(string name, MbsType type)
        {
            MbsField newField = new MbsField(name, type, size);
            fields = fields.Append(newField).ToArray();
            size += type.getSize();
            return newField;
        }

        public ComposedType getParent()
        {
            return parent;
        }

        public MbsField[] getFields()
        {
            return fields;
        }

        private Func<MbsIO, MbsObject> instantiator;

        public void setInstantiator(Func<MbsIO, MbsObject> instantiator)
        {
            this.instantiator = instantiator;
        }

        public override MbsObject createInstance(MbsIO data)
        {
            if (instantiator is not null) return instantiator(data);
            else return base.createInstance(data);
        }

        public MbsList<V> createList<V>(MbsIO data) where V : MbsObject
        {
            return new MbsList<V>(data, this, (V)createInstance(data));
        }
    }
}
