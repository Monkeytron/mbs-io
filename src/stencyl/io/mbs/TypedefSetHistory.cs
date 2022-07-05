using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.core.header;

using haxe_mbs_translate.src.stencyl.io.mbs.snippet;
using haxe_mbs_translate.src.stencyl.io.mbs.scene;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.physics;
using haxe_mbs_translate.src.stencyl.io.mbs.shape;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.layers;
namespace haxe_mbs_translate.src.stencyl.io.mbs
{
    /// <summary>
    /// This contains information about https://github.com/Stencyl/stencyl-engine/blob/master/com/stencyl/io/mbs/Typedefs.hx after each commit that changed the type definition set.
    /// This allows you to read older or newer files, and write compatible to old and new games, without changing the code.
    /// </summary>
    public static class TypedefsHistory
    {
        public static MbsTypedefSet basicTypes;

        /// <summary>
        /// commit aed884c7980477c88f777b79fb58facdc2c5aff4 "Mbs validation".
        /// This was the first time typeset hash codes were used.
        /// </summary>
        public static MbsTypedefSet mbs_validation;

        /// <summary>
        /// commit 7dd387c370439458df2b85d47bfdedb4a421c4f5 "Get rid of unused fields in GameModel".
        /// </summary>
        public static MbsTypedefSet unused_GameModel;

        /// <summary>
        /// commit bb6d10224a4e9cb0d8bf14634fb84696d3f5badd "Make disposeImages a built-in feature"
        /// </summary>
        public static MbsTypedefSet disposeImages;

        /// <summary>
        /// commit e789ba7c2273af06adfa9146386cadc85411e7d9 "In-layer ordering of actors is preserved from toolset"
        /// </summary>
        public static MbsTypedefSet in_layer_actors;

        /// <summary>
        /// commit 66d001c729943472b167b43910f4c0909d401acb "Remove unused scene format field"
        /// </summary>
        public static MbsTypedefSet remove_scene_format;

        static TypedefsHistory()
        {
            basicTypes = new MbsTypedefSet(-1684419011);
            if (true)
            {
                mbs_validation = new MbsTypedefSet(1341673740,
                    new MbsType("Undefined type MBS_RESOURCE", 0),
               new MbsType("Undefined type MBS_BACKGROUND", 0),
               new MbsType("Undefined type MBS_CUSTOM_BLOCK", 0),
               new MbsType("Undefined type MBS_BLANK", 0),
               new MbsType("Undefined type MBS_FONT", 0),
               new MbsType("Undefined type MBS_MUSIC", 0),
               new MbsType("Undefined type MBS_ACTOR_TYPE", 0),
               new MbsType("Undefined type MBS_SPRITE", 0),
               new MbsType("Undefined type MBS_ANIMATION)", 0),
               new MbsType("Undefined type MBS_ANIM_SHAPE", 0),
               new MbsType("Undefined type MBS_GAME", 0),
               new MbsType("Undefined type MBS_ATLAS", 0),
               new MbsType("Undefined type MBS_COLLISION_SHAPE", 0),
               new MbsType("Undefined type MBS_COLLISION_GROUP", 0),
               new MbsType("Undefined type MBS_COLLISION_PAIR", 0),
               new MbsType("Undefined type MBS_SCENE_HEADER", 0),
               new MbsType("Undefined type MBS_TILESET", 0),
               new MbsType("Undefined type MBS_TILE", 0),
               MbsScene.MBS_SCENE,
               MbsActorInstanceOld.MBS_ACTOR_INSTANCE_OLD,
               MbsColorBackground.MBS_COLOR_BACKGROUND,
               new MbsType("Undefined type MBS_GRADIENT_BACKGROUND", 0),
               MbsLayer.MBS_LAYER,
               MbsInteractiveLayer.MBS_INTERACTIVE_LAYER,
               MbsImageBackground.MBS_IMAGE_BACKGROUND,
               new MbsType("Undefined type MBS_JOINT", 0),
               new MbsType("Undefined type MBS_STICK_JOINT", 0),
               new MbsType("Undefined type MBS_HINGE_JOINT", 0),
               new MbsType("Undefined type MBS_SLIDING_JOINT", 0),
               MbsRegion.MBS_REGION,
               MbsTerrainRegion.MBS_TERRAIN_REGION,
               MbsPoint.MBS_POINT,
               MbsShape.MBS_SHAPE,
               new MbsType("Undefined type MBS_CIRCLE", 0),
               MbsPolygon.MBS_POLYGON,
               new MbsType("Undefined type MBS_POLY_REGION", 0),
               MbsWireframe.MBS_WIREFRAME,
               MbsSnippetDef.MBS_SNIPPET_DEF,
               MbsAttributeDef.MBS_ATTRIBUTE_DEF,
               MbsBlock.MBS_BLOCK,
               MbsEvent.MBS_EVENT,
               MbsSnippet.MBS_SNIPPET,
               MbsAttribute.MBS_ATTRIBUTE,
               MbsMapElement.MBS_MAP_ELEMENT,
               new MbsType("Undefined type MBS_AUTOTILE_FORMAT", 0),
               new MbsType("Undefined type MBS_CORNERS", 0)
                    ) ;
            } // mbs_validation
            if (true)
            {
                unused_GameModel = new MbsTypedefSet(-1134453392,
           new MbsType("Undefined type MBS_RESOURCE", 0),
           new MbsType("Undefined type MBS_BACKGROUND", 0),
           new MbsType("Undefined type MBS_CUSTOM_BLOCK", 0),
           new MbsType("Undefined type MBS_BLANK", 0),
           new MbsType("Undefined type MBS_FONT", 0),
           new MbsType("Undefined type MBS_MUSIC", 0),
           new MbsType("Undefined type MBS_ACTOR_TYPE", 0),
           new MbsType("Undefined type MBS_SPRITE", 0),
           new MbsType("Undefined type MBS_ANIMATION)", 0),
           new MbsType("Undefined type MBS_ANIM_SHAPE", 0),
           new MbsType("Undefined type MBS_GAME", 0),
           new MbsType("Undefined type MBS_ATLAS", 0),
           new MbsType("Undefined type MBS_COLLISION_SHAPE", 0),
           new MbsType("Undefined type MBS_COLLISION_GROUP", 0),
           new MbsType("Undefined type MBS_COLLISION_PAIR", 0),
           new MbsType("Undefined type MBS_SCENE_HEADER", 0),
           new MbsType("Undefined type MBS_TILESET", 0),
           new MbsType("Undefined type MBS_TILE", 0),
               MbsScene.MBS_SCENE,
               MbsActorInstanceOld.MBS_ACTOR_INSTANCE_OLD,
               MbsColorBackground.MBS_COLOR_BACKGROUND,
           new MbsType("Undefined type MBS_GRADIENT_BACKGROUND", 0),
               MbsLayer.MBS_LAYER,
               MbsInteractiveLayer.MBS_INTERACTIVE_LAYER,
               MbsImageBackground.MBS_IMAGE_BACKGROUND,
           new MbsType("Undefined type MBS_JOINT", 0),
           new MbsType("Undefined type MBS_STICK_JOINT", 0),
           new MbsType("Undefined type MBS_HINGE_JOINT", 0),
           new MbsType("Undefined type MBS_SLIDING_JOINT", 0),
               MbsRegion.MBS_REGION,
               MbsTerrainRegion.MBS_TERRAIN_REGION,
               MbsPoint.MBS_POINT,
               MbsShape.MBS_SHAPE,
           new MbsType("Undefined type MBS_CIRCLE", 0),
               MbsPolygon.MBS_POLYGON,
               new MbsType("Undefined type MBS_POLY_REGION",0),
               MbsWireframe.MBS_WIREFRAME,
           new MbsType("Undefined type MBS_WIREFRAME", 0),
               MbsSnippetDef.MBS_SNIPPET_DEF,
               MbsAttributeDef.MBS_ATTRIBUTE_DEF,
               MbsBlock.MBS_BLOCK,
               MbsEvent.MBS_EVENT,
               MbsSnippet.MBS_SNIPPET,
               MbsAttribute.MBS_ATTRIBUTE,
               MbsMapElement.MBS_MAP_ELEMENT,
           new MbsType("Undefined type MBS_AUTOTILE_FORMAT", 0),
           new MbsType("Undefined type MBS_CORNERS", 0)
           );
            } // unused_Gamemodel
            if (true)
            {
                disposeImages = new MbsTypedefSet(1466594936,
           new MbsType("Undefined type MBS_RESOURCE", 0),
           new MbsType("Undefined type MBS_BACKGROUND", 0),
           new MbsType("Undefined type MBS_CUSTOM_BLOCK", 0),
           new MbsType("Undefined type MBS_BLANK", 0),
           new MbsType("Undefined type MBS_FONT", 0),
           new MbsType("Undefined type MBS_MUSIC", 0),
           new MbsType("Undefined type MBS_ACTOR_TYPE", 0),
           new MbsType("Undefined type MBS_SPRITE", 0),
           new MbsType("Undefined type MBS_ANIMATION)", 0),
           new MbsType("Undefined type MBS_ANIM_SHAPE", 0),
           new MbsType("Undefined type MBS_GAME", 0),
           new MbsType("Undefined type MBS_ATLAS", 0),
           new MbsType("Undefined type MBS_COLLISION_SHAPE", 0),
           new MbsType("Undefined type MBS_COLLISION_GROUP", 0),
           new MbsType("Undefined type MBS_COLLISION_PAIR", 0),
           new MbsType("Undefined type MBS_SCENE_HEADER", 0),
           new MbsType("Undefined type MBS_TILESET", 0),
           new MbsType("Undefined type MBS_TILE", 0),
               MbsScene.MBS_SCENE,
               MbsActorInstanceOld.MBS_ACTOR_INSTANCE_OLD,
               MbsColorBackground.MBS_COLOR_BACKGROUND,
           new MbsType("Undefined type MBS_GRADIENT_BACKGROUND", 0),
               MbsLayer.MBS_LAYER,
               MbsInteractiveLayer.MBS_INTERACTIVE_LAYER,
               MbsImageBackground.MBS_IMAGE_BACKGROUND,
           new MbsType("Undefined type MBS_JOINT", 0),
           new MbsType("Undefined type MBS_STICK_JOINT", 0),
           new MbsType("Undefined type MBS_HINGE_JOINT", 0),
           new MbsType("Undefined type MBS_SLIDING_JOINT", 0),
               MbsRegion.MBS_REGION,
               MbsTerrainRegion.MBS_TERRAIN_REGION,
               MbsPoint.MBS_POINT,
               MbsShape.MBS_SHAPE,
           new MbsType("Undefined type MBS_CIRCLE", 0),
               MbsPolygon.MBS_POLYGON,
               new MbsType("Undefined type MBS_POLY_REGION",0),
               MbsWireframe.MBS_WIREFRAME,
               MbsSnippetDef.MBS_SNIPPET_DEF,
               MbsAttributeDef.MBS_ATTRIBUTE_DEF,
               MbsBlock.MBS_BLOCK,
               MbsEvent.MBS_EVENT,
               MbsSnippet.MBS_SNIPPET,
               MbsAttribute.MBS_ATTRIBUTE,
               MbsMapElement.MBS_MAP_ELEMENT,
           new MbsType("Undefined type MBS_AUTOTILE_FORMAT", 0),
           new MbsType("Undefined type MBS_CORNERS", 0)
           );
            } // disposeImages
            if (true)
            {
                in_layer_actors = new MbsTypedefSet(-2033963926,
           new MbsType("Undefined type MBS_RESOURCE", 0),
           new MbsType("Undefined type MBS_BACKGROUND", 0),
           new MbsType("Undefined type MBS_CUSTOM_BLOCK", 0),
           new MbsType("Undefined type MBS_BLANK", 0),
           new MbsType("Undefined type MBS_FONT", 0),
           new MbsType("Undefined type MBS_MUSIC", 0),
           new MbsType("Undefined type MBS_ACTOR_TYPE", 0),
           new MbsType("Undefined type MBS_SPRITE", 0),
           new MbsType("Undefined type MBS_ANIMATION)", 0),
           new MbsType("Undefined type MBS_ANIM_SHAPE", 0),
           new MbsType("Undefined type MBS_GAME", 0),
           new MbsType("Undefined type MBS_ATLAS", 0),
           new MbsType("Undefined type MBS_COLLISION_SHAPE", 0),
           new MbsType("Undefined type MBS_COLLISION_GROUP", 0),
           new MbsType("Undefined type MBS_COLLISION_PAIR", 0),
           new MbsType("Undefined type MBS_SCENE_HEADER", 0),
           new MbsType("Undefined type MBS_TILESET", 0),
           new MbsType("Undefined type MBS_TILE", 0),
               MbsScene.MBS_SCENE,
               MbsActorInstance.MBS_ACTOR_INSTANCE,
               MbsColorBackground.MBS_COLOR_BACKGROUND,
           new MbsType("Undefined type MBS_GRADIENT_BACKGROUND", 0),
               MbsLayer.MBS_LAYER,
               MbsInteractiveLayer.MBS_INTERACTIVE_LAYER,
               MbsImageBackground.MBS_IMAGE_BACKGROUND,
           new MbsType("Undefined type MBS_JOINT", 0),
           new MbsType("Undefined type MBS_STICK_JOINT", 0),
           new MbsType("Undefined type MBS_HINGE_JOINT", 0),
           new MbsType("Undefined type MBS_SLIDING_JOINT", 0),
               MbsRegion.MBS_REGION,
               MbsTerrainRegion.MBS_TERRAIN_REGION,
               MbsPoint.MBS_POINT,
               MbsShape.MBS_SHAPE,
           new MbsType("Undefined type MBS_CIRCLE", 0),
               MbsPolygon.MBS_POLYGON,
           new MbsType("Undefined type MBS_POLY_REGION", 0),
               MbsWireframe.MBS_WIREFRAME,
               MbsSnippetDef.MBS_SNIPPET_DEF,
               MbsAttributeDef.MBS_ATTRIBUTE_DEF,
               MbsBlock.MBS_BLOCK,
               MbsEvent.MBS_EVENT,
               MbsSnippet.MBS_SNIPPET,
               MbsAttribute.MBS_ATTRIBUTE,
               MbsMapElement.MBS_MAP_ELEMENT,
           new MbsType("Undefined type MBS_AUTOTILE_FORMAT", 0),
           new MbsType("Undefined type MBS_CORNERS", 0)
           );
            } // in_layer_actors
            if (true)
            {
                remove_scene_format = new MbsTypedefSet(-1349349184,
           new MbsType("Undefined type MBS_RESOURCE", 0),
           new MbsType("Undefined type MBS_BACKGROUND", 0),
           new MbsType("Undefined type MBS_CUSTOM_BLOCK", 0),
           new MbsType("Undefined type MBS_BLANK", 0),
           new MbsType("Undefined type MBS_FONT", 0),
           new MbsType("Undefined type MBS_MUSIC", 0),
           new MbsType("Undefined type MBS_ACTOR_TYPE", 0),
           new MbsType("Undefined type MBS_SPRITE", 0),
           new MbsType("Undefined type MBS_ANIMATION)", 0),
           new MbsType("Undefined type MBS_ANIM_SHAPE", 0),
           new MbsType("Undefined type MBS_GAME", 0),
           new MbsType("Undefined type MBS_ATLAS", 0),
           new MbsType("Undefined type MBS_COLLISION_SHAPE", 0),
           new MbsType("Undefined type MBS_COLLISION_GROUP", 0),
           new MbsType("Undefined type MBS_COLLISION_PAIR", 0),
           new MbsType("Undefined type MBS_SCENE_HEADER", 0),
           new MbsType("Undefined type MBS_TILESET", 0),
           new MbsType("Undefined type MBS_TILE", 0),
               MbsScene.MBS_SCENE,
               MbsActorInstance.MBS_ACTOR_INSTANCE,
               MbsColorBackground.MBS_COLOR_BACKGROUND,
           new MbsType("Undefined type MBS_GRADIENT_BACKGROUND", 0),
               MbsLayer.MBS_LAYER,
               MbsInteractiveLayer.MBS_INTERACTIVE_LAYER,
               MbsImageBackground.MBS_IMAGE_BACKGROUND,
           new MbsType("Undefined type MBS_JOINT", 0),
           new MbsType("Undefined type MBS_STICK_JOINT", 0),
           new MbsType("Undefined type MBS_HINGE_JOINT", 0),
           new MbsType("Undefined type MBS_SLIDING_JOINT", 0),
               MbsRegion.MBS_REGION,
               MbsTerrainRegion.MBS_TERRAIN_REGION,
               MbsPoint.MBS_POINT,
               MbsShape.MBS_SHAPE,
           new MbsType("Undefined type MBS_CIRCLE", 0),
               MbsPolygon.MBS_POLYGON,
           new MbsType("Undefined type MBS_POLY_REGION", 0),
               MbsWireframe.MBS_WIREFRAME,
               MbsSnippetDef.MBS_SNIPPET_DEF,
               MbsAttributeDef.MBS_ATTRIBUTE_DEF,
               MbsBlock.MBS_BLOCK,
               MbsEvent.MBS_EVENT,
               MbsSnippet.MBS_SNIPPET,
               MbsAttribute.MBS_ATTRIBUTE,
               MbsMapElement.MBS_MAP_ELEMENT,
           new MbsType("Undefined type MBS_AUTOTILE_FORMAT", 0),
           new MbsType("Undefined type MBS_CORNERS", 0)
           );
            } // remove_scene_format
        }
    }
}
