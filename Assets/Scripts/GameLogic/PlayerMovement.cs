using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.GameLogic
{
    public class PlayerMovement : Movement
    {

        private StateMachine MovingState;

        private StateMachine MovingMode;


        public override void OnUse()
        {
            base.OnUse();
            this.ResetVariables();
            /*
            this.pathfinding = null;
            this.MovingState = null;
            this.MovingMode = null;
            this.GravityMode = null;*/
        }

        public override void Born(ActorRoot owner)
        {/*
            base.Born(owner);
            this._MaxSpeed = 6000;
            this.MovingState = new StateMachine();
            this.MovingState.RegisterState<IdleMovmentState>(new IdleMovmentState(this), "IdleMovmentState");
            this.MovingState.RegisterState<AccelerateMovementState>(new AccelerateMovementState(this), "AccelerateMovementState");
            this.MovingState.RegisterState<UniformMovementState>(new UniformMovementState(this), "UniformMovementState");
            this.MovingState.RegisterState<DecelerateMovementState>(new DecelerateMovementState(this), "DecelerateMovementState");
            this.MovingState.ChangeState("IdleMovmentState");
            this.MovingMode = new StateMachine();
            this.MovingMode.RegisterState<AutoMovementMode>(new AutoMovementMode(this), "AutoMovementMode");
            this.MovingMode.RegisterState<DirectionalMovementMode>(new DirectionalMovementMode(this), "DirectionalMovementMode");
            this.MovingMode.RegisterState<HoldonMovementMode>(new HoldonMovementMode(this), "HoldonMovementMode");
            this.MovingMode.ChangeState("HoldonMovementMode");
            this.GravityMode = new GravityMovement(this);
            this.CreateNavSearchAgent();*/
        }

        public override void Init()
        {/*
            base.Init();
            this.GravityMode.Init();
            if (AstarPath.active != null)
            {
                this.pathfinding = new MPathfinding();
                if (!this.pathfinding.Init(this.actorPtr))
                {
                    this.pathfinding = null;
                }
            }*/
        }

        private void ResetVariables()
        {/*
            this.Acceleration = 999999;
            this._MaxSpeed = 6000;
            this.RotateSpeed = 720;
            this.DecelerateDistance = 1000;
            this.IgnoreDistance = 1;
            this.MinDecelerateSpeed = 0;
            this.bStopMoving = true;
            this.bExcecuteMoving = false;
            this.bRotatingLock = false;
            this.bRotateImmediately = false;
            this.bFlying = false;
            this.bLerpFlying = false;
            this.nLerpStep = 0;
            this.TargetLocation = VInt3.zero;
            this.Direction = VInt3.zero;
            this.MoveDirState.Reset();
            this.uCmdID = 0u;
            this.m_uiNonMoveTotalTime = 0u;
            this.m_ulLastMoveEndTime = 0uL;
            this.m_uiMoveIntervalMax = 0u;*/
        }

        public override void Fight()
        {
            base.Fight();
          //  this.m_ulLastMoveEndTime = Singleton<FrameSynchr>.instance.LogicFrameTick;
        }

        public override void Deactive()
        {
            this.ResetVariables();
            this.MovingState.ChangeState("IdleMovmentState");
            this.MovingMode.ChangeState("HoldonMovementMode");
            base.Deactive();
        }

        public override void Reactive()
        {/*
            base.Reactive();
            if (this.GravityMode != null)
            {
                this.GravityMode.Reset();
            }
            if (this.pathfinding != null)
            {
                this.pathfinding.Reset();
                if (this.pathfinding.rvo)
                {
                    this.pathfinding.rvo.maxSpeed = this.maxSpeed;
                }
            }*/
        }

        public override void StopMove()
        {/*
            this.bStopMoving = true;
            this.bExcecuteMoving = false;
            this.TargetLocation = this.actor.location;
            if (this.pathfinding != null)
            {
                this.pathfinding.StopMove();
            }
            this.MovingMode.ChangeState("HoldonMovementMode");
            this.GotoState("IdleMovmentState");
            this.m_ulLastMoveEndTime = Singleton<FrameSynchr>.instance.LogicFrameTick;*/
        }

        public override void UpdateLogic(int delta)
        {/*
            if (this.pathfinding != null)
            {
                this.pathfinding.UpdateLogic(delta);
            }
            if (this.bExcecuteMoving || this.bRotateImmediately)
            {
                ((MovementState)this.MovingState.TopState()).UpdateLogic(delta);
            }
            this.GravityMode.Move(delta);*/
        }


        public override int acceleration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isAccelerating
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isAutoMoveMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isDecelerate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isDirectionalMoveMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isExcuteMoving
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isFinished
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isFlying
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool isLerpFlying
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool isMoving
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool isRotateImmediately
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool isRotatingLock
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int maxSpeed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override MPathfinding Pathfinding
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int rotateSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int speed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override VInt3 targetLocation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override uint uCommandId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override VInt3 velocity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void ExcuteMove()
        {
            throw new NotImplementedException();
        }

        public override float GetDistance(uint nDelta)
        {
            throw new NotImplementedException();
        }

        public override void GravityModeLerp(uint nDelta, bool bReset)
        {
            throw new NotImplementedException();
        }

        public override void SetMoveParam(VInt3 InVector, bool bDirection, bool bInRotateImmediately, uint cmdId = 0)
        {
            throw new NotImplementedException();
        }

        public override void SetRotate(VInt3 InDirection, bool bInRotateImmediately)
        {
            throw new NotImplementedException();
        }

    }

}