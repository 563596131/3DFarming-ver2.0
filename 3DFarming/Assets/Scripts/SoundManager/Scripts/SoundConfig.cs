using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BaseTools
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        public SoundConfigItem[] dataList;
    }

    [System.Serializable]
    public struct SoundConfigItem
    {
        public SoundType soundType;
        public AudioClip audioClip;
    }

    public enum SoundType
    {
        // background music
        BG = 1,
        
        // ui sound effect
        BUTTON1 = 100,
        BUTTON2,
        
        // battle sound effect
        WALK = 200,
        JUMP,
        
        
        
        SKILL1 = 300,
        SKILL2,
        SKILL3,
        SKILL4,
        
        ADD_COIN = 400,
        DAMAGE,
        
        // 
        FAILD,
        SUCCEED,
    }
}