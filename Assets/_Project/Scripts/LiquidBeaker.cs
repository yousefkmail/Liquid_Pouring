using System;
using LiquidSimulation.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace LiquidSimulation.Core
{
    public class LiquidBeaker : MonoBehaviour
    {

        [ColorUsage(true, true), SerializeField] Color color;
        [SerializeField, Range(0, 1)] float filledAmount = 1f;

        [Tooltip("How much weight each molecule going to add when is dropped into the beaker, 0.001 means 1 thousands molecules to form a liter")]
        [Min(0.001f)] public float particleWeight = 0.001f;

        [Tooltip("Number of liquid particles to be emitted every second.")]

        [Min(1),] public int drainSpeed = 5;
        public bool isPlaying = false;

        public bool BlendColors = true;
        public float MoleculesInitialSpeed = 0.5f;

        [Tooltip("the time that the hostory tracker need to keep each partcile added before removing it")]
        [SerializeField] float historyTrackerLength = 1f;

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
            }
        }

        //this object will help us keep track of the latest amount of liquid added, which will help us determine the foam value, 
        // for the cup.
        public AddedLiquidhistory addedLiquidhistory = new();

        public float FilledAmount { get { return filledAmount; } set { filledAmount = value; } }


        public void AddLiquid(float amount, Color color)
        {

            //Blending between current color, and new color works by Lerping between both of them, and then setting the T that 
            //will determine the new value based on the amount of each color currently exists.

            //for example, if the first cup contained red for an amount of 0.5f, and we try to add 0.5f of the color blue,
            //the resulting will be lerp between red and blue and the T is (0.5 / (0.5 + 0.5)) = 0.5f, which will result purple.
            if (BlendColors)
            {
                Color = Color.Lerp(color, Color, FilledAmount / (FilledAmount + amount));
            }

            FilledAmount += amount;
            addedLiquidhistory.Add(amount, Time.time);
        }

        public void Update()
        {
            addedLiquidhistory.RemoveBefore(Time.time - historyTrackerLength);
        }
    }
}