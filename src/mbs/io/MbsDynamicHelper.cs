using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsDynamicHelper
    {
        public static void writeDynamic(MbsIO data, int address, dynamic obj)
        {
            if(obj is null)
            {
                data.writeTypecode(address, MbsTypes.NULL);
            }
            if(obj is bool)
            {
                data.writeTypecode(address, MbsTypes.BOOLEAN);
                data.writeBool(address + MbsTypes.INTEGER.getSize(), obj);
            }
            else if (obj is float)
            {
                data.writeTypecode(address, MbsTypes.FLOAT);
                data.writeFloat(address + MbsTypes.INTEGER.getSize(), obj);
            }
            else if (obj is int)
            {
                data.writeTypecode(address, MbsTypes.INTEGER);
                data.writeInt(address + MbsTypes.INTEGER.getSize(), obj);
            }
            else if (obj is string)
            {
                data.writeTypecode(address, MbsTypes.STRING);
                data.writeString(address + MbsTypes.INTEGER.getSize(), obj);
            }
            else
            {
                data.writeTypecode(address, obj.getMbsType());
                data.writeInt(address + MbsTypes.INTEGER.getSize(), obj.getAddress());
            }
        }

        public static dynamic readDynamic(MbsIO data, int address)
        {
            MbsType type = data.readTypecode(address);
            if (type == MbsTypes.NULL) return null;
            else if (type == MbsTypes.BOOLEAN) return data.readBool(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.FLOAT) return data.readFloat(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.INTEGER) return data.readInt(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.STRING) return data.readString(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.LIST)
            {
                address = data.readInt(address + MbsTypes.INTEGER.getSize());
                if (address != 0)
                {
                    type = data.readTypecode(address + MbsTypes.INTEGER.getSize());
                    MbsListBase list = null;

                    if (type == MbsTypes.BOOLEAN) list = new MbsBoolList(data);
                    else if (type == MbsTypes.FLOAT) list = new MbsFloatList(data);
                    else if (type == MbsTypes.INTEGER) list = new MbsIntList(data);
                    else if (type == MbsTypes.STRING) list = new MbsStringList(data);
                    else if (type == MbsTypes.DYNAMIC) list = new MbsDynamicList(data);
                    else
                    {
                        list = new MbsList<MbsObject>(data, type, type.createInstance(data)); // Bug possibility
                    }

                    list.setAddress(address);
                    return list;
                }
                return null;
            }
            else
            {
                MbsObject obj = type.createInstance(data);
                obj.setAddress(data.readInt(address + MbsTypes.INTEGER.getSize()));
                return obj;
            }
        }

        public static Dictionary<MbsType, MbsObject> createObjectPool (MbsIO data)
        {
            return new Dictionary<MbsType, MbsObject>();
        }

        public static dynamic readDynamicUsingPool(MbsIO data, int address, Dictionary<MbsType, MbsObject> pool)
        {
            MbsType type = data.readTypecode(address);
            if (type == MbsTypes.NULL) return null;
            else if (type == MbsTypes.BOOLEAN) return data.readBool(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.FLOAT) return data.readFloat(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.INTEGER) return data.readInt(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.STRING) return data.readString(address + MbsTypes.INTEGER.getSize());
            else if (type == MbsTypes.LIST)
            {
                address = data.readInt(address + MbsTypes.INTEGER.getSize());
                if (address != 0)
                {
                    type = data.readTypecode(address + MbsTypes.INTEGER.getSize());
                    MbsListBase list = null;

                    if (type == MbsTypes.BOOLEAN) list = new MbsBoolList(data);
                    else if (type == MbsTypes.FLOAT) list = new MbsFloatList(data);
                    else if (type == MbsTypes.INTEGER) list = new MbsIntList(data);
                    else if (type == MbsTypes.STRING) list = new MbsStringList(data);
                    else if (type == MbsTypes.DYNAMIC) list = new MbsDynamicList(data);
                    else list = new MbsList<MbsObject>(data, type, type.createInstance(data)); // Bug possibility

                    list.setAddress(address);
                    return list;
                }
                return null;
            }
            else
            {
                MbsObject obj = null;
                if (!pool.ContainsKey(type))
                {
                    obj = type.createInstance(data);
                    pool.Add(type, obj);
                }
                else
                {
                    obj = pool[type];
                    if(obj == null)
                    {
                        obj = type.createInstance(data);
                        pool[type] = obj;
                    }
                }

                obj.setAddress(data.readInt(address + MbsTypes.INTEGER.getSize()));
                return obj;
            }
        }
    }
}
