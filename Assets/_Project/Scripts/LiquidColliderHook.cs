using System;
using UnityEngine;
namespace LiquidSimulation.Utils
{
    //this component is hooked to a collider that need to transmit its collider messages.
    public class LiquidColliderHook : MonoBehaviour
    {

        public event Action<GameObject> OnParticleCollisionHook;

        void OnParticleCollision(GameObject other)
        {
            OnParticleCollisionHook?.Invoke(other);
        }
    }
}