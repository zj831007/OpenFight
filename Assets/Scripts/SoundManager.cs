﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SoundManager:Singleton<SoundManager>
    {

        public enum BankType
        {
            Global,
            Lobby,
            Battle,
            LevelMusic
        }

        private GameObject m_soundRoot;

        private List<string>[] m_loadedBanks;

        private bool m_isPrepared;

        public override void Init()
        {
            this.m_soundRoot = new GameObject("SoundManager");
            GameObject gameObject = GameObject.Find("BootObj");
            if(gameObject != null)
            {
                this.m_soundRoot.transform.parent = gameObject.transform;
            }
            this.m_loadedBanks = new List<string>[Enum.GetNames(typeof(SoundManager.BankType)).Length];

            for(int i = 0; i < this.m_loadedBanks.Length; i++)
            {
                this.m_loadedBanks[i] = new List<string>();
            }
            this.m_isPrepared = false;
        }


        public void Prepare()
        {
            if (this.m_isPrepared)
            {
                return;
            }
            this.m_soundRoot.AddComponent<AkTerminator>();
            this.m_soundRoot.AddComponent<AkInitializer>();
            this.m_isPrepared = true;
        }

        public uint PostEvent(string eventName, GameObject srcGameObject = null)
        {
            if (!this.m_isPrepared)
            {
                return 0u;
            }
            if(srcGameObject == null)
            {
                if(Camera.main != null)
                {
                    srcGameObject = Camera.main.gameObject;
                }
                else
                {
                    srcGameObject = this.m_soundRoot;
                }
            }
            else
            {
                return AkSoundEngine.PostEvent(eventName, srcGameObject);
            }
            return 0u;
        }

        public void LoadBank(string bankName, SoundManager.BankType bankType)
        {
            if (!this.m_isPrepared)
            {
                return;
            }
            if (this.m_loadedBanks[(int)bankType].Contains(bankName))
            {
                return;
            }
            if (AkInitializer.s_loadBankFromMemory)
            {
                //Load from assetbundle
                string soundBankPathInResources = AkInitializer.GetSoundBankPathInResources(bankName);

            }
            else
            {
                AkBankManager.LoadBank(bankName);
            }
            this.m_loadedBanks[(int)bankType].Add(bankName);
        }

        public void UnLoadBank(string bankName, SoundManager.BankType bankType)
        {
            if (!this.m_isPrepared) {
                return;
            }
            if (this.m_loadedBanks[(int)bankType].Remove(bankName))
            {
                AkBankManager.UnloadBank(bankName);
            }
        }

        public void UnloadBanks(SoundManager.BankType bankType)
        {
            if (!this.m_isPrepared)
            {
                return;
            }
            List<string> list = this.m_loadedBanks[(int)bankType];
            for (int i = 0; i < list.Count; i++)
            {
                AkBankManager.UnloadBank(list[i]);
            }
            list.Clear();
        }

        public uint PlayBattleSound(string eventName, PoolObjHandle<ActorRoot> actor, GameObject srcGameObject = null)
        {
            if (!GameSettings.EnableSound || MonoSingleton<Reconnection>.GetInstance().isProcessingRelayRecover || (actor && !actor.handle.Visible))
            {
                return 0u;
            }
            return this.PostEvent(eventName, srcGameObject);
        }

        public uint PlayBattleSound2D(string eventName)
        {
            if (!GameSettings.EnableSound || MonoSingleton<Reconnection>.GetInstance().isProcessingRelayRecover)
            {
                return 0u;
            }
            return this.PostEvent(eventName, null);
        }

        public uint PlayHeroActSound(string soundName)
        {
            if (!GameSettings.EnableSound || MonoSingleton<Reconnection>.GetInstance().isProcessingRelayRecover)
            {
                return 0u;
            }
            if (string.IsNullOrEmpty(soundName))
            {
                return 0u;
            }
            Player hostPlayer = Singleton<GamePlayerCenter>.instance.GetHostPlayer();
            if (hostPlayer.Captain && hostPlayer.Captain.handle.ActorControl != null && !hostPlayer.Captain.handle.ActorControl.IsDeadState)
            {
                return this.PostEvent(soundName, hostPlayer.Captain.handle.gameObject);
            }
            return this.PostEvent(soundName, null);
        }

        public void LoadHeroSoundBank(string bankName)
        {
            int num = 1;
            if (!this.m_loadedBanks[num].Contains(bankName))
            {
                if (this.m_loadedBanks[num].get_Count() >= 10)
                {
                    this.UnLoadBank(this.m_loadedBanks[num].get_Item(0), CSoundManager.BankType.Lobby);
                }
                this.LoadBank(bankName, CSoundManager.BankType.Lobby);
            }
            else
            {
                this.m_loadedBanks[num].Remove(bankName);
                this.m_loadedBanks[num].Add(bankName);
            }
        }

        public void LoadSkinSoundBank(uint heroId, uint skinId, GameObject obj, bool bLobby)
        {
            ResHeroSkin heroSkin = CSkinInfo.GetHeroSkin(heroId, skinId);
            if (heroSkin == null && skinId != 0u)
            {
                heroSkin = CSkinInfo.GetHeroSkin(heroId, 0u);
            }
            if (heroSkin != null)
            {
                if (!string.IsNullOrEmpty(heroSkin.szSkinSoundResPack))
                {
                    if (bLobby)
                    {
                        this.LoadHeroSoundBank(heroSkin.szSkinSoundResPack + "_Show");
                    }
                    else
                    {
                        this.LoadBank(heroSkin.szSkinSoundResPack + "_SFX", SoundManager.BankType.Battle);
                        this.LoadBank(heroSkin.szSkinSoundResPack + "_VO", SoundManager.BankType.Battle);
                    }
                }
                if (!string.IsNullOrEmpty(heroSkin.szSoundSwitchEvent))
                {
                    this.PostEvent(heroSkin.szSoundSwitchEvent, obj);
                }
            }
            else
            {
                DebugHelper.Assert(false, "Default sound resource can not find heroId = {0}skinId ={1}", new object[]
                {
                    heroId,
                    skinId
                });
            }
        }


    }
}
