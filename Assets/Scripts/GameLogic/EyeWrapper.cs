using UnityEngine;
using System.Collections;

namespace Assets.Scripts.GameLogic
{
    public class EyeWrapper : ObjWrapper
    {
        private const string DeadAnimName = "Eye_Dead";

        public bool bLifeTimeOver;

        private int lifeTime;

        public int lifeTimeTotal
        {
            get;
            private set;
        }

        public int LifeTime
        {
            get
            {
                return this.lifeTime;
            }
            set
            {
                this.lifeTime = value;
                this.lifeTimeTotal = value;
                this.UpdateTimerBar();
            }
        }
        private void UpdateTimerBar()
        {/*
            if (this.actor.HudControl != null)
            {
                this.actor.HudControl.UpdateTimerBar(this.lifeTime, this.lifeTimeTotal);
            }*/
        }

    }
}