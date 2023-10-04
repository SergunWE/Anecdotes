using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandexSDK.Scripts
{
    
    /// <summary>
    /// Data that is downloaded and stored from outside, such as Yandex Games.
    /// </summary>
    [Serializable]
    public class SaveInfo
    {
        //level
        [field: SerializeField] public int LevelNumber { get; set; }

        //settings
        [field: SerializeField] public bool MusicOn { get; set; } = true;
        [field: SerializeField] public bool SoundOn { get; set; } = true;
        [field: SerializeField] public string ManualLanguage { get; set; }

        //pumping
        [field: SerializeField] public int Coins { get; set; }
        [field: SerializeField] public int DailyRewardLevel { get; set; }
        [field: SerializeField] public long DailyRewardTimeTicks { get; set; }
        [field: SerializeField] public int SpeedLevel { get; set; }
        [field: SerializeField] public int GravityLevel { get; set; }
        [field: SerializeField] public int PushingForceLevel { get; set; }

        //other
        [field: SerializeField] public Color PlayerColor { get; set; } = Color.white;
        [field: SerializeField] public long LastSaveTimeTicks { get; set; }

        //customization
        [field: SerializeField] public int PlayerSkinId { get; set; }

        [field: SerializeField] public List<int> PlayerPurchasedSkins { get; set; } = new() { 0 };

        [field: SerializeField] public int StoneSkinIndex { get; set; }
    }
}