using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.io
{
    /// <summary>
    /// This might be buggy, generic types seem to work differently in haxe?
    /// You don't need to sprecify what T is when initialising them in haxe, possibly.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MbsList<T>:MbsListBase where T:MbsObject
    {
        private T obj;

        public MbsList(MbsIO data, MbsType type, T _obj) : base(data, type)
        {
            obj = _obj; 
        }
        public T getNextObject()
        {
            obj.setAddress(elementAddress);
            elementAddress += elementSize;
            return obj;
        }
    }
}
