using System;
using Unity.Mathematics;
using UnityEngine;

namespace LiquidSimulation.Core
{


    public class LiquidBeakerTransformHandler : MonoBehaviour
    {
        [SerializeField] LiquidBeaker liquidBeaker;

        [SerializeField] int minDrainSpeed = 5;
        [SerializeField] int maxDrainSpeed = 30;

        [SerializeField] float minInitialSpeed = 0.3f;
        [SerializeField] float maxInitialSpeed = 0.6f;

        public AnimationCurve AngleToPourRation;

        void Update()
        {
            AdjustLiquidPourForRotation();
        }

        //this will determine whether the cup is currently pouring on not, based on the current X value of the cup.
        //by calculating how much the current angle exceeds the angle at which is defined by the curve for the filled
        //amount, we can determine the draining speed of our cup, after that we clamp it between 2 values to ensure 
        // consistancy.
        void AdjustLiquidPourForRotation()
        {
            if (AngleToPourRation.Evaluate(liquidBeaker.FilledAmount) < Vector3.Angle(Vector3.up, transform.up))
            {
                liquidBeaker.isPlaying = true;
                int ClampedDrainSpeed = (int)math.clamp(Vector3.Angle(Vector3.up, transform.up) - AngleToPourRation.Evaluate(liquidBeaker.FilledAmount), minDrainSpeed, maxDrainSpeed);
                liquidBeaker.drainSpeed = ClampedDrainSpeed;
                liquidBeaker.MoleculesInitialSpeed = math.lerp(minInitialSpeed, maxInitialSpeed, (float)(liquidBeaker.drainSpeed - minDrainSpeed) / (float)(maxDrainSpeed - minDrainSpeed));

            }
            else
            {
                liquidBeaker.isPlaying = false;
            }
        }
    }

}