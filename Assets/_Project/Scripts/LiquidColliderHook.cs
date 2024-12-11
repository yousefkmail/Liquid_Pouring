using System;
using UnityEngine;
namespace LiquidSimulation.Utils
{
    public class LiquidColliderHook : MonoBehaviour
    {

        public event Action<GameObject> OnParticleCollisionHook;

        void OnParticleCollision(GameObject other)
        {
            OnParticleCollisionHook?.Invoke(other);
        }
    }
}