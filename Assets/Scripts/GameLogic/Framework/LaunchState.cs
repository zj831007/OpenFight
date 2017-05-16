using UnityEngine;
using System.Collections;
namespace Assets.Scripts.Framework
{
    [GameState]
    public class LaunchState : BaseState
    {
        private bool m_isSplashPlayComplete;

        private bool m_isBaseSystemPrepareComplete;

        private bool m_jumpState;


        public override void OnStateEnter()
        {
            // 加载splashscene,完成时调用
            // LoadScene(SplashScene, OnSplashLoadCompleted )

            this.m_isSplashPlayComplete = false;
            this.m_isBaseSystemPrepareComplete = false;
        }


        private void OnSplashLoadCompleted()
        {

        }

        private void OnSplashPlayComplete(int timerSequence)
        {
            this.m_isSplashPlayComplete = true;
            this.CheckContionToNextState();
        }

        private void OnCheatSystemDisable()
        {
            this.CheckContionToNextState();
        }

        private void CheckContionToNextState()
        {
            //if (this.m_isSplashPlayComplete && this.m_isBaseSystemPrepareComplete && !Singleton<CCheatSystem>.GetInstance().m_enabled && !this.m_jumpState)
            //{
            //    this.m_jumpState = true;
            //    Singleton<GameStateCtrl>.GetInstance().GotoState("VersionUpdateState");
            //}
        }
    }
}
    