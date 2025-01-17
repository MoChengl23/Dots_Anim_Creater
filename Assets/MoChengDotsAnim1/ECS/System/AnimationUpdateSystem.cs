// using System.ComponentModel.DataAnnotations;
using System.Numerics;
// using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine.Jobs;
using Unity.Mathematics;
using Unity.Burst;
using UnityEngine.Profiling;
using Unity.Rendering;

[BurstCompile]

public partial struct UpdateFrameJob : IJobEntity
{
    public float deltaTime;
    public EntityCommandBuffer.ParallelWriter ecbPara;



    void Execute(ref AnimationData animationData)
    {
        var currentTime = animationData.currentTime + deltaTime;
        var animationLength = animationData.currentAnimation.length;
        var totalFrames = animationData.currentAnimation.totalFrames;

        animationData.currentTime =
        currentTime < animationLength ?
        currentTime : currentTime - animationLength;

        float normalizedTime = currentTime / animationLength;

        animationData.currentFrame = math.min((int)math.round(normalizedTime * totalFrames), totalFrames - 1);


        //

    }
}




 
public partial struct TestJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ecbPara;
    // public UnitScriptableObject beSpawnedUnitSpriptableObject;
    void Execute([EntityInQueryIndex] int entityInQueryIndex, Entity e, in RenderMesh renderMesh, ref AnimationData animationData)
    {
        AnimationUtil.CrossfadeAnimation("walk", e, ref animationData, ecbPara, entityInQueryIndex);
        // Debug.Log("Start work");

    }
}
public partial struct TestJob1 : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ecbPara;
    // public UnitScriptableObject beSpawnedUnitSpriptableObject;
    void Execute([EntityInQueryIndex] int entityInQueryIndex, Entity e, in RenderMesh renderMesh, ref AnimationData animationData)
    {
        AnimationUtil.CrossfadeAnimation("IdleManBored", e, ref animationData, ecbPara, entityInQueryIndex);


    }
}
public partial struct TestJob2 : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ecbPara;
    // public UnitScriptableObject beSpawnedUnitSpriptableObject;
    void Execute([EntityInQueryIndex] int entityInQueryIndex, Entity e, in RenderMesh renderMesh, ref AnimationData animationData)
    {
        AnimationUtil.CrossfadeAnimation("MineWorking", e, ref animationData, ecbPara, entityInQueryIndex);


    }
}
// [AlwaysUpdateSystem]
public partial class AnimationUpdateSystem : ServiceSystem
{
    private EntityQueryDesc dntNeedCrossfade = new EntityQueryDesc
    {

    };
    int sum = 0;
    protected override void OnCreate()
    {
        Debug.Log(11);
    }
    protected override void OnStartRunning()
    {

        Debug.Log(EntityManager);

        var beSpawnedUnitSpriptableObject = Resources.Load<UnitScriptableObject>("Unit");
        Debug.Log(beSpawnedUnitSpriptableObject);
        beSpawnedUnitSpriptableObject.CreateItself();

         
    }


    protected override void OnUpdate()
    {
        var deltaTime = UnityEngine.Time.deltaTime;
        // sum += 1;
        var intsum = (int)sum;
        StaticData.shaderTime = StaticData._shaderTime;




        if (Input.GetMouseButtonDown(0))
        {
            var beSpawnedUnitSpriptableObject = Resources.Load<UnitScriptableObject>("Unit");
            beSpawnedUnitSpriptableObject.CreateItself();

        }


        var dontNeedCrossfadeQuery = GetEntityQuery(dntNeedCrossfade);
        var updateFrameJobHandle = new UpdateFrameJob
        {
            deltaTime = deltaTime,
            ecbPara = ecbPara

        }.ScheduleParallel();
        updateFrameJobHandle.Complete();
        


    }



}


