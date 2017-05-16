using UnityEngine;
using System.Collections;


namespace Assets.Scripts.GameLogic
{

    public class OrganWrapper : ObjWrapper
    {

        public const string OrganAroundEffectHomePath = "Prefab_Characters/Prefab_Organ/AroundEffect/";

        public const string AttackLinkerPrefab = "AttackLinker";


        private int _attackOneTargetCounter;  //攻击一个目标计数

        private int _attackOneTargetCounterLast;

        private int _aroundEnemyMonsterCount; //周围敌怪数量

        private bool m_bFirstAttacked;

        private long attackDistSqr;
    }
}