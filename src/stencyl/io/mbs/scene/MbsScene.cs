using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;

using haxe_mbs_translate.src.stencyl.io.mbs.shape;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.physics;

namespace haxe_mbs_translate.src.stencyl.io.mbs.scene
{
    /// <summary>
    /// In layer actors and later
    /// </summary>
    public class MbsScene : MbsObject
    {
        public static MbsField retainAtlases;
        public static MbsField depth;
        public static MbsField description;
        public static MbsField eventSnippetID;
        public static MbsField extendedHeight;
        public static MbsField extendedWidth;
        public static MbsField extendedX;
        public static MbsField extendedY;
        public static MbsField format;
        public static MbsField gravityX;
        public static MbsField gravityY;
        public static MbsField height;
        public static MbsField id;
        public static MbsField name;
        public static MbsField revision;
        public static MbsField savecount;
        public static MbsField tileDepth;
        public static MbsField tileHeight;
        public static MbsField tileWidth;
        public static MbsField type;
        public static MbsField width;
        public static MbsField actorInstances;
        public static MbsField atlasMembers;
        public static MbsField layers;
        public static MbsField joints;
        public static MbsField regions;
        public static MbsField snippets;
        public static MbsField terrain;
        public static MbsField terrainRegions;

        public static ComposedType MBS_SCENE;
        static MbsScene()
        {
            MBS_SCENE = new ComposedType("MbsScene");
            MBS_SCENE.setInstantiator(data => new MbsScene(data));

            retainAtlases = MBS_SCENE.createField("retainAtlases", MbsTypes.BOOLEAN);
            depth = MBS_SCENE.createField("depth", MbsTypes.INTEGER);
            description = MBS_SCENE.createField("description", MbsTypes.STRING);
            eventSnippetID = MBS_SCENE.createField("eventSnippetID", MbsTypes.INTEGER);
            extendedHeight = MBS_SCENE.createField("extendedHeight", MbsTypes.INTEGER);
            extendedWidth = MBS_SCENE.createField("extendedWidth", MbsTypes.INTEGER);
            extendedX = MBS_SCENE.createField("extendedX", MbsTypes.INTEGER);
            extendedY = MBS_SCENE.createField("extendedY", MbsTypes.INTEGER);
            format = MBS_SCENE.createField("format", MbsTypes.STRING);
            gravityX = MBS_SCENE.createField("gravityX", MbsTypes.FLOAT);
            gravityY = MBS_SCENE.createField("gravityY", MbsTypes.FLOAT);
            height = MBS_SCENE.createField("height", MbsTypes.INTEGER);
            id = MBS_SCENE.createField("id", MbsTypes.INTEGER);
            name = MBS_SCENE.createField("name", MbsTypes.STRING);
            revision = MBS_SCENE.createField("revision", MbsTypes.STRING);
            savecount = MBS_SCENE.createField("savecount", MbsTypes.INTEGER);
            tileDepth = MBS_SCENE.createField("tileDepth", MbsTypes.INTEGER);
            tileHeight = MBS_SCENE.createField("tileHeight", MbsTypes.INTEGER);
            tileWidth = MBS_SCENE.createField("tileWidth", MbsTypes.INTEGER);
            type = MBS_SCENE.createField("type", MbsTypes.STRING);
            width = MBS_SCENE.createField("width", MbsTypes.INTEGER);
            actorInstances = MBS_SCENE.createField("actorInstances", MbsTypes.LIST);
            atlasMembers = MBS_SCENE.createField("atlasMembers", MbsTypes.LIST);
            layers = MBS_SCENE.createField("layers", MbsTypes.LIST);
            joints = MBS_SCENE.createField("joints", MbsTypes.LIST);
            regions = MBS_SCENE.createField("regions", MbsTypes.LIST);
            snippets = MBS_SCENE.createField("snippets", MbsTypes.LIST);
            terrain = MBS_SCENE.createField("terrain", MbsTypes.LIST);
            terrainRegions = MBS_SCENE.createField("terrainRegions", MbsTypes.LIST);

        }

        public static MbsList<MbsScene> new_MbsSceneNew_list(MbsIO data)
        {
            return new MbsList<MbsScene>(data, MBS_SCENE, new MbsScene(data));
        }

        override public MbsType getMbsType()
        {
            return MBS_SCENE;
        }

        private MbsList<MbsActorInstance> _actorInstances;
        private MbsList<MbsActorInstanceOld> _oldActorInstances;
        private MbsIntList _atlasMembers;
        private MbsDynamicList _layers;
        private MbsDynamicList _joints;
        private MbsList<MbsRegion> _regions;
        private MbsList<MbsSnippet> _snippets;
        private MbsList<MbsWireframe> _terrain;
        private MbsList<MbsTerrainRegion> _terrainRegions;

        public MbsScene(MbsIO data) : base(data)
        {
            _actorInstances = MbsActorInstance.new_MbsActorInstance_list(data);
            _oldActorInstances = MbsActorInstanceOld.new_MbsActorInstanceOld_list(data);
            _atlasMembers = new MbsIntList(data);
            _layers = new MbsDynamicList(data);
            _joints = new MbsDynamicList(data);
            _regions = MbsRegion.new_MbsRegion_list(data);
            _snippets = MbsSnippet.new_MbsSnippet_list(data);
            _terrain = MbsWireframe.new_MbsWireframe_list(data);
            _terrainRegions = MbsTerrainRegion.new_MbsTerrainRegion_list(data);
        }


        public void allocateNew()
        {
            setAddress(data.allocate(MBS_SCENE.getSize()));
        }

        public bool getRetainAtlases()
        {
            return data.readBool(address + retainAtlases.address);
        }
        public void setRetainAtlases(bool _val)
        {
            data.writeBool(address + retainAtlases.address, _val);
        }

        public int getDepth()
        {
            return data.readInt(address + depth.address);
        }
        public void setDepth(int _val)
        {
            data.writeInt(address + depth.address, _val);
        }

        public string getDescription()
        {
            return data.readString(address + description.address);
        }
        public void setDescription(string _val)
        {
            data.writeString(address + description.address, _val);
        }

        public int getEventSnippetID()
        {
            return data.readInt(address + eventSnippetID.address);
        }
        public void setEventSnippetID(int _val)
        {
            data.writeInt(address + eventSnippetID.address, _val);
        }

        public int getExtendedHeight()
        {
            return data.readInt(address + extendedHeight.address);
        }
        public void setExtendedHeight(int _val)
        {
            data.writeInt(address + extendedHeight.address, _val);
        }

        public int getExtendedWidth()
        {
            return data.readInt(address + extendedWidth.address);
        }
        public void setExtendedWidth(int _val)
        {
            data.writeInt(address + extendedWidth.address, _val);
        }

        public int getExtendedX()
        {
            return data.readInt(address + extendedX.address);
        }
        public void setExtendedX(int _val)
        {
            data.writeInt(address + extendedX.address, _val);
        }

        public int getExtendedY()
        {
            return data.readInt(address + extendedY.address);
        }
        public void setExtendedY(int _val)
        {
            data.writeInt(address + extendedY.address, _val);
        }

        public string getFormat()
        {
            return data.readString(address + format.address);
        }
        public void setFormat(string _val)
        {
            data.writeString(address + format.address, _val);
        }

        public float getGravityX()
        {
            return data.readFloat(address + gravityX.address);
        }
        public void setGravityX(float _val)
        {
            data.writeFloat(address + gravityX.address, _val);
        }

        public float getGravityY()
        {
            return data.readFloat(address + gravityY.address);
        }
        public void setGravityY(float _val)
        {
            data.writeFloat(address + gravityY.address, _val);
        }

        public int getHeight()
        {
            return data.readInt(address + height.address);
        }
        public void setHeight(int _val)
        {
            data.writeInt(address + height.address, _val);
        }

        public int getId()
        {
            return data.readInt(address + id.address);
        }
        public void setId(int _val)
        {
            data.writeInt(address + id.address, _val);
        }

        public string getName()
        {
            return data.readString(address + name.address);
        }
        public void setName(string _val)
        {
            data.writeString(address + name.address, _val);
        }

        public string getRevision()
        {
            return data.readString(address + revision.address);
        }
        public void setRevision(string _val)
        {
            data.writeString(address + revision.address, _val);
        }

        public int getSavecount()
        {
            return data.readInt(address + savecount.address);
        }
        public void setSavecount(int _val)
        {
            data.writeInt(address + savecount.address, _val);
        }

        public int getTileDepth()
        {
            return data.readInt(address + tileDepth.address);
        }
        public void setTileDepth(int _val)
        {
            data.writeInt(address + tileDepth.address, _val);
        }

        public int getTileHeight()
        {
            return data.readInt(address + tileHeight.address);
        }
        public void setTileHeight(int _val)
        {
            data.writeInt(address + tileHeight.address, _val);
        }

        public int getTileWidth()
        {
            return data.readInt(address + tileWidth.address);
        }
        public void setTileWidth(int _val)
        {
            data.writeInt(address + tileWidth.address, _val);
        }

        public string getType()
        {
            return data.readString(address + type.address);
        }
        public void setType(string _val)
        {
            data.writeString(address + type.address, _val);
        }

        public int getWidth()
        {
            return data.readInt(address + width.address);
        }
        public void setWidth(int _val)
        {
            data.writeInt(address + width.address, _val);
        }

        public MbsList<MbsActorInstance> getActorInstances()
        {
            _actorInstances.setAddress(data.readInt(address + actorInstances.address));
            return _actorInstances;
        }
        public MbsList<MbsActorInstance> createActorInstances(int _length)
        {
            _actorInstances.allocateNew(_length);
            data.writeInt(address + actorInstances.address, _actorInstances.getAddress());
            return _actorInstances;
        }

        public MbsList<MbsActorInstanceOld> getOldActorInstances()
        {
            _oldActorInstances.setAddress(data.readInt(address + actorInstances.address));
            return _oldActorInstances;
        }
        public MbsList<MbsActorInstanceOld> createOldActorInstances(int _length)
        {
            _oldActorInstances.allocateNew(_length);
            data.writeInt(address + actorInstances.address, _actorInstances.getAddress());
            return _oldActorInstances;
        }

        public MbsIntList getAtlasMembers()
        {
            _atlasMembers.setAddress(data.readInt(address + atlasMembers.address));
            return _atlasMembers;
        }
        public MbsIntList createAtlasMembers(int _length)
        {
            _atlasMembers.allocateNew(_length);
            data.writeInt(address + atlasMembers.address, _atlasMembers.getAddress());
            return _atlasMembers;
        }

        public MbsDynamicList getLayers()
        {
            _layers.setAddress(data.readInt(address + layers.address));
            return _layers;
        }
        public MbsDynamicList createLayers(int _length)
        {
            _layers.allocateNew(_length);
            data.writeInt(address + layers.address, _layers.getAddress());
            return _layers;
        }

        public MbsDynamicList getJoints()
        {
            _joints.setAddress(data.readInt(address + joints.address));
            return _joints;
        }
        public MbsDynamicList createJoints(int _length)
        {
            _joints.allocateNew(_length);
            data.writeInt(address + joints.address, _joints.getAddress());
            return _joints;
        }

        public MbsList<MbsRegion> getRegions()

        {
            _regions.setAddress(data.readInt(address + regions.address));
            return _regions;
        }
        public MbsList<MbsRegion> createRegions(int _length)

        {
            _regions.allocateNew(_length);
            data.writeInt(address + regions.address, _regions.getAddress());
            return _regions;
        }

        public MbsList<MbsSnippet> getSnippets()
        {
            _snippets.setAddress(data.readInt(address + snippets.address));
            return _snippets;
        }
        public MbsList<MbsSnippet> createSnippets(int _length)
        {
            _snippets.allocateNew(_length);
            data.writeInt(address + snippets.address, _snippets.getAddress());
            return _snippets;
        }

        public MbsList<MbsWireframe> getTerrain()

        {
            _terrain.setAddress(data.readInt(address + terrain.address));
            return _terrain;
        }
        public MbsList<MbsWireframe> createTerrain(int _length)

        {
            _terrain.allocateNew(_length);
            data.writeInt(address + terrain.address, _terrain.getAddress());
            return _terrain;
        }

        public MbsList<MbsTerrainRegion> getTerrainRegions()

        {
            _terrainRegions.setAddress(data.readInt(address + terrainRegions.address));
            return _terrainRegions;
        }
        public MbsList<MbsTerrainRegion> createTerrainRegions(int _length)

        {
            _terrainRegions.allocateNew(_length);
            data.writeInt(address + terrainRegions.address, _terrainRegions.getAddress());
            return _terrainRegions;
        }
    }
}
