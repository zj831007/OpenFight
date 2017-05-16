using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Framework
{
    [AutoSingleton(false)]
    public class GameFramework : MonoSingleton<GameFramework>
    {
        public delegate void DelegateOnBaseSystemPrepareComplete();

        public static string AppVersion;

        public static int c_renderFPS = 30;

        public static float c_targetFrameTime = 1000f / (float)GameFramework.c_renderFPS;

        public double lastRealTime;

        private bool lockFPS_SGame = true;

        public bool EditorPreviewMode;

        public bool CreateReplayFile = true;

        private bool m_isBaseSystemPrepared;

        private bool m_isAllSystemPrepared;

        private float frequency = 0.1f;

        public static float m_fFps = 0f;

        private float accumTime;

        private float lastUpdateTime;

        private Vector3 _DebugPreCamPos;

        private float _DebugPreCamTime;


        public static int unityTargetFrameRate
        {
            get
            {
                int num = GameFramework.c_renderFPS;
                return 60;
            }
        }

        public void setTargetFrameRate()
        {
            if (this.lockFPS_SGame)
            {
                Application.targetFrameRate = GameFramework.unityTargetFrameRate;
                base.StartCoroutine("SGame_WaitForTargetFrameRate");
            }
            else
            {
                base.StopCoroutine("SGame_WaitForTargetFrameRate");
                Application.targetFrameRate = GameFramework.c_renderFPS;
            }
        }

        public void StartPrepareBaseSystem(GameFramework.DelegateOnBaseSystemPrepareComplete delegateOnBaseSystemPrepareComplete)
        {
            base.StartCoroutine(this.PrepareBaseSystem(delegateOnBaseSystemPrepareComplete));
        }


        private IEnumerator PrepareBaseSystem(GameFramework.DelegateOnBaseSystemPrepareComplete delegateOnBaseSystemPrepareComplete)
        {
            yield return null;
        }

        public void PrepareSoundSystem(bool applySoundSettings = false)
        {

        }


        public IEnumerator PrepareGameSystem()
        {
            yield return null;
        }

        protected override void Init()
        {
            Screen.sleepTimeout = -1;

            this.setTargetFrameRate();
        }


        private IEnumerator SGame_WaitForTargetFrameRate()
        {
            yield return null;
        }

        protected void InitBaseSys()
        {
            //
            Singleton<GameStateCtrl>.CreateInstance();
            //OutlineFilter.EnableSurfaceShaderOutline(false);
            //DynamicShadow.InitDefaultGlobalVariables();
        }

        protected void InitCoreSys()
        {

        }

        protected void InitPeripherySys()
        {
        }

        protected void InitBattleSys()
        {
        }

        protected void InitMiscSys()
        {
        }

        public virtual void Start()
        {
            Application.runInBackground = true;
            try
            {
                DebugHelper.CustomLog("GameFramework Start, Version:{0}.R({1}), Unity:{2}", new object[]
                {
     
                    Application.unityVersion
                });
            }
            catch (Exception)
            {
            }
        
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = 5;
           
            
            Debug.Log("android EnableInput");
            
            this.InitBaseSys();
            Singleton<GameStateCtrl>.GetInstance().Initialize();
            Singleton<GameStateCtrl>.GetInstance().GotoState("LaunchState");
        }

        private void Update()
        {
           
            this.UpdateElse();
        }

        private void UpdateElse()
        {
            
        }

        private void LateUpdate()
        {
            
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
           
        }

        protected void DestroyBaseSys()
        {
            
        }

        protected void DestroyCoreSys()
        {
            
        }

        protected void DestoryPeripherySys()
        {
           
        }

        protected void DestoryBattleSys()
        {
           
        }

        protected void DestoryMiscSys()
        {
            
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            DebugHelper.CustomLog("OnApplicationPause {0}", new object[]
            {
                pauseStatus
            });
        }

        private void OnApplicationFocus(bool focus)
        {
            
        }
    }
}
