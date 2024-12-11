using System.Collections.Generic;

namespace LiquidSimulation.Utils
{

    public class AddedLiquidhistory
    {

        public struct LiquidDrop
        {
            public float time;
            public float amount;
        }

        public Queue<LiquidDrop> liquidDrops = new();


        public void RemoveBefore(float time)
        {

            while (true)
            {
                if (liquidDrops.Count < 1)
                    break;
                if (liquidDrops.Peek().time < time)
                    liquidDrops.Dequeue();
                else
                {
                    break;
                }
            }

        }

        public float TotlaAmount()
        {
            float amount = 0;
            foreach (LiquidDrop liquidDrop in liquidDrops)
            {
                amount += liquidDrop.amount;
            }
            return amount;
        }


        public void Add(float amount, float time)
        {
            liquidDrops.Enqueue(new LiquidDrop() { amount = amount, time = time });
        }
    }
}