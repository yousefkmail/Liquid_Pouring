using Unity.Mathematics;
using UnityEngine;


namespace LiquidSimulation.Core

{



    //this component will use the liquid beaker and foam mesh to add foam effet to the beaker when being poured into,
    // it uses different values from the beaker such as FilledAmount to determine the position of the foam,
    // it will also use the collision component to determine the number of particles added to this beaker in
    // the last second and apply foam based on it.
    [ExecuteAlways]
    public class LiquidFoam : MonoBehaviour
    {
        [SerializeField] Transform foamDisk;

        [SerializeField] LiquidBeaker liquidBeaker;
        public new Renderer renderer;

        [SerializeField] bool applyFoam = true;

        [SerializeField] float minFoamStrength = 0;
        [SerializeField] float maxFoamStrength = 0.5f;

        [SerializeField] float minAmountToCauseFoam = 0f;
        [SerializeField] float maxAmountToIncreaseFoam = 0.2f;


        public bool ApplyFoam
        {
            set
            {
                applyFoam = value;
                foamDisk.gameObject.SetActive(applyFoam);
            }
            get { return applyFoam; }
        }

        void Update()
        {
            UpdateFoamVisuals();
        }

        void UpdateFoamVisuals()
        {
            foamDisk.gameObject.SetActive(applyFoam);

            if (foamDisk && liquidBeaker)
            {


                if (Application.isPlaying)
                {
                    renderer.material.SetFloat("_FoamStrength", math.lerp(minFoamStrength, maxFoamStrength, math.clamp((liquidBeaker.addedLiquidhistory.TotlaAmount() - minAmountToCauseFoam) / (maxAmountToIncreaseFoam - minAmountToCauseFoam), 0, 1)));
                }
            }
        }
    }
}