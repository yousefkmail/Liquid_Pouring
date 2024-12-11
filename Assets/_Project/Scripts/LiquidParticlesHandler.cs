using UnityEngine;
using UnityEngine.UIElements;

namespace LiquidSimulation.Core
{


    //this script is the actual simulation of the molecules of the water being dropped, it  will work by emiting partciles each frame based on 
    //the current drain speed, and amount exceeding the 1 will drop immediately, as the cup can't hold.
    public class LiquidParticlesHandler : MonoBehaviour
    {
        [SerializeField] LiquidBeaker liquidBeaker;
        float timeUntilNextParticle = 0;
        [SerializeField] ParticleSystem WaterStream;
        [SerializeField] ParticleSystem waterDrops;

        void Update()
        {

            var mainModule = WaterStream.main;
            mainModule.startSpeed = liquidBeaker.MoleculesInitialSpeed;

            //drop all molecules exceeding the 1;
            if (liquidBeaker.FilledAmount > 1)
            {
                while (liquidBeaker.FilledAmount > 1)
                {

                    liquidBeaker.FilledAmount -= liquidBeaker.particleWeight;
                    WaterStream.Emit(1);
                }
            }

            //stop if the beakers stopped playing.
            if (!liquidBeaker.isPlaying || liquidBeaker.FilledAmount < liquidBeaker.particleWeight)
            {
                waterDrops.Stop();
                return;
            }


            // this loop is for emitting partciles, at low frame rate, it will emit multiple molecules in each frame
            // the while loop ensures that the frame rate does not limit draining speed.
            while (timeUntilNextParticle < 0)
            {
                timeUntilNextParticle += 1f / liquidBeaker.drainSpeed;
                liquidBeaker.FilledAmount -= liquidBeaker.particleWeight;
                WaterStream.Emit(1);
            }


            timeUntilNextParticle -= Time.deltaTime;
            if (!waterDrops.isPlaying)
            {
                waterDrops.Play();
            }
        }

    }
}