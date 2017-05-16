﻿using System;
using System.Collections;
using System.Diagnostics;

namespace Assets.Scripts.Framework
{
    public class EditorFramework : GameFramework
    {
        protected override void Init()
        {
            base.Init();
            base.StartPrepareBaseSystem(new GameFramework.DelegateOnBaseSystemPrepareComplete(this.OnPrepareBaseSystemComplete));
        }

        public override void Start()
        {
            
            Singleton<GameStateCtrl>.GetInstance().Initialize();
        }

        private void OnPrepareBaseSystemComplete()
        {
            base.StartCoroutine(this.StartPrepareGameSystem());
        }

        [DebuggerHidden]
        private IEnumerator StartPrepareGameSystem()
        {
            yield return null;
        }
    }
}
