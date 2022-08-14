using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

using Unity.Mathematics;
using System;
using System.Linq;
using UnityEngine.Rendering;

public enum UnitType
{

};
[System.Serializable]
public struct Item
{
    public string name;
    public int2 renderRange;
}

[CreateAssetMenu(menuName = "ScriptableObject/Create MyScriptableObject ")]
public class UnitScriptableObject : ScriptableObject
{
    public Mesh mainMesh;
    // public Mesh subMesh;
    public Material mainMaterial;
    // public Material subMaterial;
    public UnitType unitType;


 
    public AnimationScriptableObject defaultAnimation;



    public List<AnimationScriptableObject> animations;
    [Header("RenderRange contains all render part")]
    [Header("#You should modify by index in AnimationScriptableObject#")]
    [Tooltip("Player speeds, etc")]
    public List<Item> renderRange;


    // ------------------method below


    private EntityManager EntityManager
    {
        get
        {
            if (entityManager == default(EntityManager))
            {
                entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            }
            return entityManager;
        }
    }
    private EntityManager entityManager;



    public Entity CreateItself( )
    {
        var entity = EntityManager.CreateEntity(SpawnUtil.UnitArchetype);


        var names = animations.Select(x => x.animationName).ToArray();
        AnimationUtil.AddAnimationList(animations, mainMaterial, renderRange);

        AnimationUtil.PlayAnimation(defaultAnimation.name, entity);
        InitUnitComponent(  entity);
        return entity;

    }



    private void InitUnitComponent(  Entity entity)
    {
        EntityManager.AddSharedComponentData<RenderMesh>(entity,
        new RenderMesh
        {
            mesh = mainMesh,
            material = mainMaterial,
            layerMask = 1,
            castShadows = ShadowCastingMode.On

        });

        EntityManager.SetComponentData<Rotation>(entity,
           new Rotation { Value = new float4(0, 0, 0, 1) }
       );
        // EntityManager.SetComponentData<NonUniformScale>(entity,
        //     new NonUniformScale { Value = new float3(1, 1, 1) }
        // );
        EntityManager.SetComponentData<BuiltinMaterialPropertyUnity_WorldTransformParams>(entity,
            new BuiltinMaterialPropertyUnity_WorldTransformParams { Value = new float4(0, 0, 0, 1) }
        );
        EntityManager.SetComponentData<BuiltinMaterialPropertyUnity_LightData>(entity,
        new BuiltinMaterialPropertyUnity_LightData { Value = new float4(0, 0, 1, 0) }
        );
        EntityManager.SetComponentData<BuiltinMaterialPropertyUnity_RenderingLayer>(entity,
        new BuiltinMaterialPropertyUnity_RenderingLayer { Value = new uint4(1, 0, 0, 0) });
        EntityManager.AddComponentData<AnimationData>(entity, new AnimationData
        {
            currentAnimation = defaultAnimation.animElement

        });





    }

    // private void SetAnimtionStuff(Material material)
    // {
    //     var names = animations.Select(x => x.animationName).ToArray();
    //     AnimationUtil.AddAnimationList(animations, material);


    // }

}
