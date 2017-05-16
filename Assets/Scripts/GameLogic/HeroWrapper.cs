using UnityEngine;
using System.Collections;
namespace Assets.Scripts.GameLogic
{

    public class HeroWrapper : ObjWrapper
    {
        private int multiKillNum;  //多杀次数

        private int contiKillNum; //杀人次数

        private int contiDeadNum; //死亡次数

        private bool autoRevived; 

        public bool bGodMode;

        private uint[] m_talentArr = new uint[5];

        private uint m_skinCfgId;

        private uint m_skinId;

    }
}