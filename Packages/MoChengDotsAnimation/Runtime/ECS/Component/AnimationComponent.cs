using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
namespace MoChengDotsAnimation
{
    public struct AnimationData : IComponentData
    {
        public AnimationElement currentAnimation;
        public int currentFrame;
        public float currentTime;
    }
}
