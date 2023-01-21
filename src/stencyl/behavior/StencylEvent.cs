using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;

namespace haxe_mbs_translate.src.stencyl.behavior
{
    public class StencylEvent
    {
        public string displayName;
        public bool enabled;
        public int id;
        public string name;
        public int order;
        public bool repeats;

        public StencylEvent(string displayName, bool enabled, int id, string name, int order, bool repeats)
        {
            this.displayName = displayName;
            this.enabled = enabled;
            this.id = id;
            this.name = name;
            this.order = order;
            this.repeats = repeats;
        }

        public static StencylEvent FromMbs(MbsEvent e)
        {
            return new StencylEvent(e.getDisplayName(), e.getEnabled(), e.getId(), e.getName(), e.getOrder(), e.getRepeats());
        }

        public override string ToString()
        {
            return $"Event {id} \"{name}\" \"{displayName}\":\n\tenabled = {enabled}, repeats = {repeats}, order = {order}";
        }

        public MbsEvent WriteMbs(MbsEvent e)
        {
            e.setDisplayName(displayName);
            e.setEnabled(enabled);
            e.setId(id);
            e.setName(name);
            e.setOrder(order);
            e.setRepeats(repeats);

            return e;
        }
    }
}
