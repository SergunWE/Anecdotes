using System;
using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

namespace Anecdotes
{
    public class FullscreenAdManager : MonoBehaviour
    {
        public static FullscreenAdManager Instance { get; private set; }
        
        [SerializeField] private int delayStartup;
        [SerializeField] private int delaySeconds;

        private static DateTime _adTime;
        private static readonly DateTime StartTime;

        public event Action AdClosed;
        static FullscreenAdManager()
        {
            StartTime = DateTime.UtcNow;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public bool CanShowAd()
        {
            return DateTime.UtcNow - StartTime > TimeSpan.FromSeconds(delayStartup) &&
                   DateTime.UtcNow - _adTime > TimeSpan.FromSeconds(delaySeconds);
        }

        public void ShowAd()
        {
            if (CanShowAd())
            {
                YandexGamesManager.ShowSplashAdv(gameObject, nameof(AdCallback));
            }
        }

        public void AdCallback(int result)
        {
            switch (result)
            {
                case -1:
                    PauseManager.Instance.ResumeGame();
                    AdClosed?.Invoke();
                    break;
                case 0:
                    PauseManager.Instance.PauseGame();
                    break;
                case 1:
                    PauseManager.Instance.ResumeGame();
                    _adTime = DateTime.UtcNow;
                    AdClosed?.Invoke();
                    break;
            }
        }
    }
}