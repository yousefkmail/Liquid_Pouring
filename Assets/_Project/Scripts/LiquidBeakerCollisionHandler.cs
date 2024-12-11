using LiquidSimulation.Utils;
using UnityEngine;

namespace LiquidSimulation.Core
{

    //component that will add the functionality of being able to collider with other particles and add its value to the cup.
    public class LiquidBeakerCollisionHandler : MonoBehaviour
    {
        [SerializeField] LiquidBeaker liquidBeaker;

        [SerializeReference] LiquidColliderHook liquidColliderHook;
        LiquidBeaker Other;

        void OnEnable()
        {
            liquidColliderHook.OnParticleCollisionHook += OnParticleCollision;
        }
        void OnDisable()
        {

            liquidColliderHook.OnParticleCollisionHook -= OnParticleCollision;

        }
        void OnParticleCollision(GameObject other)
        {
            if (other.transform.root.gameObject.TryGetComponent(out Other))
            {
                liquidBeaker.AddLiquid(Other.particleWeight, Other.Color);
            }
        }
    }
}