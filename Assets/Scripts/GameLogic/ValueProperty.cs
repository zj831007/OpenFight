using UnityEngine;
using System.Collections;

namespace Assets.Scripts.GameLogic
{
    public class ValueProperty : LogicComponent
    {


        private struct RangeConfig
        {
            public int MinValue;

            public int MaxValue;

            public int Attenuation;

            public static int Clamp(int value, int min, int max)
            {
                return (value >= min) ? ((value <= max) ? value : max) : min;
            }

            public bool Intersect(int InBase, int InMin, int InMax, out int OutMin, out int OutMax)
            {
                OutMin = (OutMax = 0);
                int num = this.MinValue + InBase;
                int num2 = this.MaxValue + InBase;
                if (InMax < num)
                {
                    return false;
                }
                if (InMin > num2)
                {
                    return false;
                }
                OutMin = ValueProperty.RangeConfig.Clamp(InMin, num, num2);
                OutMax = ValueProperty.RangeConfig.Clamp(InMax, num, num2);
                return true;
            }
        }



        public override void Init()
        {
            base.Init();

        }


        public override void Uninit()
        {
            base.Uninit();

        }


        public override void Deactive()
        {

            base.Deactive();
        }

        public override void Reactive()
        {
            base.Reactive();
            this.Init();
        }

        public override void Fight()
        {
            base.Fight();
        }

        public override void UpdateLogic(int nDelta)
        {
        }
    }
}