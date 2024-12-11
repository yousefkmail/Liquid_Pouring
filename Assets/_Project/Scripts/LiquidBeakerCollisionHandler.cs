using LiquidSimulation.Utils;
using UnityEngine;

namespace LiquidSimulation.Core
{


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