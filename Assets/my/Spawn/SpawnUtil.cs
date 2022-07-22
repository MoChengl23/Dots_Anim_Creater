using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

public static class SpawnUtil
{
    public static ComponentType[] UnitArchetype
    {
        get
        {
            if (unitArchetype == null)
            {
                unitArchetype = new ComponentType[]{
                typeof(RenderMesh),
                typeof(LocalToWorld),
                // typeof(NonUniformScale),
                typeof(Translation),
                typeof(Rotation),
                typeof(RenderBounds),
                typeof(BuiltinMaterialPropertyUnity_WorldTransformParams),
                typeof(BlendProbeTag),
                typeof(PerInstanceCullingTag),
                typeof(WorldToLocal_Tag),
                typeof(BuiltinMaterialPropertyUnity_RenderingLayer),
                typeof(BuiltinMaterialPropertyUnity_LightData),


                typeof(_AnimData),
                typeof(_CrossfadeData),
                typeof(_RenderRange),

                };

            }
            return unitArchetype;
        }
    }
    private static ComponentType[] unitArchetype;









}
