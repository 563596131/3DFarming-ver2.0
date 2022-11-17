using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BaseTools
{
    public class SoundMgr : MonoBehaviour
    {
        public static SoundMgr Instance;
        public AudioSource bgAudiosource;

        public AudioSource soundAudiosource;

        public SoundConfig soundConfig;
        public bool defaultPlayBg;
        public bool dontDestroy;
        
        #region public
        public void PlayMusic(SoundType soundType = SoundType.BG)
        {
            AudioClip clip = GetAudioClip(soundType);
            if (clip != null)
            {
                bgAudiosource.clip = clip;
                bgAudiosource.Play();
            }
        }
        
        public void PlaySound(SoundType soundType)
        {
            AudioClip clip = GetAudioClip(soundType);
            if (clip != null)
            {
                soundAudiosource.PlayOneShot(clip);
            }
        }

        public AudioClip GetAudioClip(SoundType soundType)
        {
            SoundConfigItem item;
            for (int i = 0; i < soundConfig.dataList.Length; i++)
            {
                item = soundConfig.dataList[i];
                if (item.soundType == soundType)
                {
                    return item.audioClip;
                }
            }

            return null;
        }
        #endregion

        #region private

        private void Awake()
        {
            Instance = this;
            if (dontDestroy) DontDestroyOnLoad(gameObject);
            if (defaultPlayBg)
            {
                PlayMusic();
            }
        }

        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        #region Test
        #if false
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayMusic();
            }else if (Input.GetKeyDown(KeyCode.B))
            {
                PlaySound(SoundType.BUTTON1);
            }
        }
        #endif
        #endregion
    }
    

}