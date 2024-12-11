using Unity.Mathematics;
using UnityEngine;

namespace LiquidSimulation.Core
{


    [RequireComponent(typeof(LiquidBeaker)), ExecuteAlways]
    public class BeakerMaterialUpdate : MonoBehaviour
    {

        LiquidBeaker liquidBeaker;
        void Start()
        {
            liquidBeaker = GetComponent<LiquidBeaker>();
        }
        [SerializeField] Renderer LiquidContainerRenderer;
        [SerializeField] ParticleSystem liquidMainStream;
        [SerializeField] ParticleSystem liquidDrainDrops;
        [SerializeField] ParticleSystem liquidDrainDrops1;

        void Update()
        {


            if (!Application.isPlaying)
            {
                LiquidContainerRenderer.sharedMaterial.SetColor("_DeepColor", liquidBeaker.Color);
                LiquidContainerRenderer.sharedMaterial.SetFloat("_LiquidAmount", liquidBeaker.FilledAmount);

                liquidMainStream.GetComponent<ParticleSystemRenderer>().sharedMaterial.SetColor("_Color", liquidBeaker.Color);
                liquidDrainDrops.GetComponent<ParticleSystemRenderer>().sharedMaterial.SetColor("_Color", liquidBeaker.Color);
                liquidDrainDrops1.GetComponent<ParticleSystemRenderer>().sharedMaterial.SetColor("_Color", liquidBeaker.Color);

            }
            else
            {
                LiquidContainerRenderer.material.SetColor("_DeepColor", liquidBeaker.Color);
                LiquidContainerRenderer.material.SetFloat("_LiquidAmount", liquidBeaker.FilledAmount);

                liquidMainStream.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", liquidBeaker.Color);
                liquidDrainDrops.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", liquidBeaker.Color);
                liquidDrainDrops1.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", liquidBeaker.Color);
            }

        }
    }
}