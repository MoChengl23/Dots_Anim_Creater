using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Unity.Entities;
 







[CreateAssetMenu(menuName = "ScriptableObject/Create MySc eObject ")]
public class AnimationScriptableObject : ScriptableObject
{
    public string animationName;

    

    [HideInInspector]
    public int vertexCount;
    [HideInInspector]
    public int totalFrames;
    [HideInInspector]
    public float3 animScalar;
    [HideInInspector]
    public float length;
    [HideInInspector]
    public int2 textureSize;
    [HideInInspector]
    public int textureCount;
 
    public List<Texture2D> textures;
 







    [HideInInspector]
    //动态赋值
    public int textureIndex;
    [HideInInspector]


    public int4x4 renderRange;
[HideInInspector]
    public AnimationElement animElement;
    [Header("Render Indexs need modify by your self")]
    [Header("It represents which part should render in this anim")]
    public List<int> renderIndexs;

}
