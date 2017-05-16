using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Common;


namespace Assets.Scripts.GameLogic
{
    public class ActorComponent : BaseComponent, IPooledMonoBehaviour, IActorComponent
    {
        [HideInInspector]
        public ActorRoot actor;

        public PoolObjHandle<ActorRoot> actorPtr;


        public void Born(ActorRoot owner)
        {
            throw new NotImplementedException();
        }

        public void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void OnGet()
        {
            throw new NotImplementedException();
        }

        public void OnRecycle()
        {
            throw new NotImplementedException();
        }

        public void UpdateLogic(int delta)
        {
            throw new NotImplementedException();
        }


    }
}
