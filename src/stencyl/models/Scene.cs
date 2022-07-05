using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.behavior;
using haxe_mbs_translate.src.stencyl.io.mbs.scene;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.layers;
using haxe_mbs_translate.src.stencyl.io.mbs.shape;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;
using haxe_mbs_translate.src.stencyl.models.scene;

namespace haxe_mbs_translate.src.stencyl.models
{
    public class Scene
    {
        public bool retainAtlases;
        public int depth;
        public string description;
        public int eventSnippetID;
        public int extendedHeight;
        public int extendedWidth;
        public int extendedX;
        public int extendedY;
        public string format;
        public float gravityX;
        public float gravityY;
        public int height;
        public int id;
        public string name;
        public string revision;
        public int savecount;
        public int tileDepth;
        public int tileHeight;
        public int tileWidth;
        public string type;
        public int width;
        public ActorInstance[] actorInstances;
        public int[] atlasMembers;
        public dynamic[] layers;
        public dynamic[] joints;//NO
        public dynamic[] regions;//NO
        public BehaviorInstance[] snippets;
        public Wireframe[] terrain;
        public dynamic[] terrainRegions;//NO

        public Scene(bool retainAtlases, int depth, string description, int eventSnippetID,
            int extendedWidth, int extendedHeight, int extendedX, int extendedY, string format,
            float gravityX, float gravityY, int height, int id, string name, string revision,
            int savecount, int tileDepth, int tileHeight, int tileWidth, string type, int width,
            ActorInstance[] actorInstances, int[] atlasMembers, dynamic[] layers,
            dynamic[] joints, dynamic[] regions, BehaviorInstance[] snippets,
            Wireframe[] terrain, dynamic[] terrainRegions)
        {
            this.retainAtlases = retainAtlases;
            this.depth = depth;
            this.description = description;
            this.eventSnippetID = eventSnippetID;
            this.extendedWidth = extendedWidth;
            this.extendedHeight = extendedHeight;
            this.extendedX = extendedX;
            this.extendedY = extendedY;
            this.format = format;
            this.gravityX = gravityX;
            this.gravityY = gravityY;
            this.height = height;
            this.id = id;
            this.name = name;
            this.revision = revision;
            this.savecount = savecount;
            this.tileDepth = tileDepth;
            this.tileHeight = tileHeight;
            this.tileWidth = tileWidth;
            this.type = type;
            this.width = width;
            this.actorInstances = actorInstances;
            this.atlasMembers = atlasMembers;
            this.layers = layers;
            this.joints = joints;
            this.regions = regions;
            this.snippets = snippets;
            this.terrain = terrain;
            this.terrainRegions = terrainRegions;
        }

        public static Scene FromMbs(MbsScene mbs)
        {
            if(mbs.getJoints().length() != 0)
            {
                throw new Exception("This scene contains joints: joint reading is not currently supported.");
            }
            else if(mbs.getRegions().length() != 0)
            {
                throw new Exception("This scene contains regions: region reading is not currently supported.");
            }
            else if (mbs.getTerrainRegions().length() != 0)
            {
                throw new Exception("This scene contains terrain regions: terrain region reading is not currently supported.");
            }
            else
            {
                MbsList<MbsActorInstance> actors = mbs.getActorInstances();
                MbsIntList atlases = mbs.getAtlasMembers();
                MbsDynamicList layers = mbs.getLayers();
                MbsList<MbsSnippet> snippets = mbs.getSnippets();
                MbsList<MbsWireframe> frames = mbs.getTerrain();
                return new Scene(mbs.getRetainAtlases(), mbs.getDepth(), mbs.getDescription(), mbs.getEventSnippetID(),
                    mbs.getExtendedWidth(), mbs.getExtendedHeight(), mbs.getExtendedX(), mbs.getExtendedY(), mbs.getFormat(),
                    mbs.getGravityX(), mbs.getGravityY(), mbs.getHeight(), mbs.getId(), mbs.getName(), mbs.getRevision(),
                    mbs.getSavecount(), mbs.getTileDepth(), mbs.getTileHeight(), mbs.getTileWidth(), mbs.getType(), mbs.getWidth(),
                    new ActorInstance[actors.length()].Select(i => ActorInstance.FromMbs(actors.getNextObject())).ToArray(),
                    new int[atlases.length()].Select(i => atlases.readInt()).ToArray(),
                    new dynamic[layers.length()].Select(i =>
                    {
                        dynamic l = layers.readObject();
                        if (l is MbsLayer) return Layer.FromMbsGeneral(l);
                        else return ColorBackground.FromMbs(l);
                    }).ToArray(),
                    new dynamic[0],
                    new dynamic[0],
                    new BehaviorInstance[snippets.length()].Select(i => BehaviorInstance.FromMbs(snippets.getNextObject())).ToArray(),
                    new Wireframe[frames.length()].Select(i => Wireframe.FromMbs(frames.getNextObject())).ToArray(),
                    new dynamic[0]);
            }
        }

        public override string ToString()
        {
            return ToString(false, false, false, false, false);
        }

        public string ToString(bool expandActors, bool expandLayers, bool expandSnippets, bool expandAttributes, bool expandWireframes)
        {
            string output = $"Scene {id} \"{name}\":";
            output += $"\n\tDescription: {description}, Type:{type}";
            output += $"\n\tFormat: {format}, revision:{revision}, Event snippet ID:{eventSnippetID}";
            output += $"\n\tSavecount:{savecount}, Retain Atlases:{retainAtlases}";
            output += $"\n\tWidth:{width}, Height:{height}, Depth:{depth}, ExWidth:{extendedWidth}, ExHeight:{extendedHeight}";
            output += $"\n\tExX:{extendedX}, ExY:{extendedY}";
            output += $"\n\tGravityX:{gravityX}, GravityY:{gravityY}";
            output += $"\n\tTile Depth:{tileDepth}, Tile Height:{tileHeight}, Tile Width: {tileWidth}";
            output += $"\n\n\tActors: Count = {actorInstances.Length}";
            if (expandActors) output += "\n\t\t" + string.Join("\n\n\t\t", actorInstances.Select(i => i.ToString(expandSnippets, expandAttributes).Replace("\n", "\n\t\t")));
            output += $"\n\n\tAtlases: Count = {atlasMembers.Length}";
            output += "\n\t\t" + string.Join(',', atlasMembers);
            output += $"\n\n\tLayers: Count = {layers.Length}";
            if (expandLayers) output += "\n\t\t" + string.Join("\n\n\t\t", layers.Select(i => i.ToString().Replace("\n", "\n\t\t")));
            output += "\n\n\tJoints: Not currently supported.";
            output += "\n\n\tRegions: Not currently supported.";
            output += $"\n\n\tSnippets: Count = {snippets.Length}";
            if (expandSnippets) output += "\n\t\t" + string.Join("\n\n\t\t", snippets.Select(i => i.ToString(expandAttributes).Replace("\n", "\n\t\t")));
            output += $"\n\n\tTerrain: Consists of {terrain.Length} wireframes";
            output += "\n\t\t" + string.Join("\n\n\t\t", terrain.Select(i => i.ToString(expandWireframes).Replace("\n", "\n\t\t")));
            output += "\n\n\tTerrain Regions: Not currently supported";

            return output;
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsScene WriteMbs(MbsScene mbs, bool isOldActors)
        {
            if (joints.Length != 0 || regions.Length != 0 || terrainRegions.Length != 0) throw new Exception("This scene has values which are not currently supported, and cannot be written.");

            mbs.setName(name);
            mbs.setType(type);
            mbs.setFormat(format);

            mbs.setRetainAtlases(retainAtlases);
            mbs.setDepth(depth);
            mbs.setDescription(description);
            mbs.setEventSnippetID(eventSnippetID);
            mbs.setExtendedWidth(extendedWidth);
            mbs.setExtendedHeight(extendedHeight);
            mbs.setExtendedX(extendedX);
            mbs.setExtendedY(extendedY);
            mbs.setGravityX(gravityX);
            mbs.setGravityY(gravityY);
            mbs.setHeight(height);
            mbs.setId(id);
            mbs.setRevision(revision);
            mbs.setSavecount(savecount);
            mbs.setTileDepth(tileDepth);
            mbs.setTileHeight(tileHeight);
            mbs.setTileWidth(tileWidth);
            mbs.setWidth(width);

            MbsDynamicList list2 = mbs.createLayers(layers.Length);
            foreach (dynamic d in layers)
            {
                dynamic l = null;
                if (d is InteractiveLayer)
                {
                    l = new MbsInteractiveLayer(mbs.GetMbs());
                }
                else if (d is ImageBackground)
                {
                    l = new MbsImageBackground(mbs.GetMbs());
                }
                else if (d is Layer)
                {
                    l = new MbsLayer(mbs.GetMbs());
                }
                else if (d is ColorBackground)
                {
                    l = new MbsColorBackground(mbs.GetMbs());
                }
                l.allocateNew();
                list2.writeObject(d.WriteMbs(l));
            }

            mbs.createJoints(0); mbs.createRegions(0); mbs.createTerrainRegions(0);

            MbsList<MbsSnippet> list3 = mbs.createSnippets(snippets.Length);
            foreach (BehaviorInstance b in  snippets) b.WriteMbs(list3.getNextObject());

            MbsList<MbsWireframe> list4 = mbs.createTerrain(terrain.Length);
            foreach (Wireframe w in terrain) w.WriteMbs(list4.getNextObject());

            if (!isOldActors)
            {
                MbsList<MbsActorInstance> list = mbs.createActorInstances(actorInstances.Length);
                foreach (ActorInstance a in actorInstances) a.WriteMbs(list.getNextObject());
            }
            else
            {
                MbsList<MbsActorInstanceOld> list = mbs.createOldActorInstances(actorInstances.Length);
                foreach (ActorInstance a in actorInstances) a.WriteMbs(list.getNextObject());
            }

            MbsIntList list1 = mbs.createAtlasMembers(atlasMembers.Length);
            foreach (int i in atlasMembers) list1.writeInt(i);


            return mbs;
        }
    }
}
