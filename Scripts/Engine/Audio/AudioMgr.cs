﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter
{
    [TMonoSingletonAttribute("[Tools]/AudioMgr")]
    public partial class AudioMgr : TMonoSingleton<AudioMgr>
    {
        private const string SOUND_STATE_RECORD_KEY = "sound_state_key_1087";
        private const string MUSIC_STATE_RECORD_KEY = "music_state_key_1088";

        protected int m_MaxCacheSoundCount = 5;
        protected int m_MaxPlaySoundCount = -1;
        protected AudioUnit m_MainUnit;
        protected Dictionary<string, AudioUnit> m_SingletonSoundMap = new Dictionary<string, AudioUnit>();
        protected bool m_IsSoundEnable = true;
        protected bool m_IsMusicEnable = true;

        public bool isSoundEnable
        {
            get { return m_IsSoundEnable; }
            set
            {
                if (m_IsSoundEnable == value)
                {
                    return;
                }

                m_IsSoundEnable = value;

                PlayerPrefs.SetInt(SOUND_STATE_RECORD_KEY, m_IsSoundEnable ? 1 : 0);

                AudioSource[] coms = GetComponents<AudioSource>();

                for (int i = 0; i < coms.Length; ++i)
                {
                    if (coms[i] != m_MainUnit.audioSource)
                    {
                        coms[i].enabled = m_IsSoundEnable;
                    }
                }
            }
        }

        public bool isMusicEnable
        {
            get { return m_IsMusicEnable; }
            set
            {
                if (m_IsMusicEnable == value)
                {
                    return;
                }

                m_IsMusicEnable = value;

                PlayerPrefs.SetInt(MUSIC_STATE_RECORD_KEY, m_IsMusicEnable ? 1 : 0);

                AudioSource[] coms = GetComponents<AudioSource>();

                if (m_MainUnit.audioSource != null)
                {
                    m_MainUnit.audioSource.enabled = m_IsMusicEnable;
                }
            }
        }

        public int maxPlaySoundCount
        {
            get { return m_MaxPlaySoundCount; }
            set
            {
                if (m_MaxPlaySoundCount == value)
                {
                    return;
                }

                m_MaxPlaySoundCount = value;

                if (m_MaxPlaySoundCount > m_MaxCacheSoundCount)
                {
                    m_MaxCacheSoundCount = m_MaxPlaySoundCount;
                }

                ObjectPool<AudioUnit>.S.maxCreateCount = m_MaxPlaySoundCount;
            }
        }

        public override void OnSingletonInit()
        {
            m_IsSoundEnable = PlayerPrefs.GetInt(SOUND_STATE_RECORD_KEY, 1) > 0;
            m_IsMusicEnable = PlayerPrefs.GetInt(MUSIC_STATE_RECORD_KEY, 1) > 0;

            ObjectPool<AudioUnit>.S.Init(m_MaxCacheSoundCount, 1);
            m_MainUnit = AudioUnit.Allocate();
            m_MainUnit.usedCache = false;
        }

        public int PlayBg(string name, bool loop = true, Action<int> callBack = null, int customEventID = -1)
        {
            m_MainUnit.SetAudio(gameObject, name, loop, m_IsMusicEnable);
            m_MainUnit.SetOnFinishListener(callBack);
            m_MainUnit.customEventID = customEventID;
            return m_MainUnit.id;
        }

        public int PlaySound(string name, bool loop = false, Action<int> callBack = null, int customEventID = -1)
        {
            if (string.IsNullOrEmpty(name))
            {
                return -1;
            }

            AudioUnit unit = AudioUnit.Allocate();

            if (unit == null)
            {
                return -1;
            }

            unit.SetAudio(gameObject, name, loop, m_IsSoundEnable);
            unit.SetOnFinishListener(callBack);
            unit.customEventID = customEventID;
            return unit.id;
        }

        public int PlaySoundShoot(string name)
        {
            if (m_SingletonSoundMap.ContainsKey(name))
            {
                var unit = m_SingletonSoundMap[name];
                unit.PlayShoot();
                return unit.id;
            }
            else
            {
                int id = PlaySound(name, false);

                if (id < 0)
                {
                    return id;
                }

                AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
                unit.SetOnStopListener(OnSingleAudioFinish);
                m_SingletonSoundMap.Add(name, unit);
                return unit.id;
            }
        }

        public int PlaySoundSingleton(string name, bool replace)
        {
            if (m_SingletonSoundMap.ContainsKey(name))
            {
                if (replace)
                {
                    m_SingletonSoundMap[name].Stop();
                    m_SingletonSoundMap.Remove(name);
                }
                else
                {
                    return -1;
                }
            }

            int id = PlaySound(name, false);

            if (id < 0)
            {
                return id;
            }

            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            unit.SetOnStopListener(OnSingleAudioFinish);
            m_SingletonSoundMap.Add(name, unit);
            return unit.id;
        }

        public bool Resume(int id)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.Resume();
            return true;
        }

        public bool Pause(int id)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.Pause();
            return true;
        }

        public bool Stop(int id)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.Stop();
            return true;
        }

        public bool SetVolume(int id, float volume)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.SetVolume(volume);
            return true;
        }

        public bool SetPitch(int id, float pitch)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.SetPitch(pitch);
            return true;
        }

        public bool SetOnFinishListener(int id, Action<int> l)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                return false;
            }

            unit.SetOnFinishListener(l);
            return true;
        }

        private void OnSingleAudioFinish(int id)
        {
            AudioUnit unit = AudioUnit.GetAudioUnitByID(id);
            if (unit == null)
            {
                Log.e("WTF! Not Impossible.");
                return;
            }

            if (m_SingletonSoundMap.ContainsKey(unit.audioName))
            {
                m_SingletonSoundMap.Remove(unit.audioName);
            }
        }

        public int GetBGID()
        {
            return m_MainUnit.id;
        }
    }
}
