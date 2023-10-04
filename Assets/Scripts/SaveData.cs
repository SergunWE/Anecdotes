using System;
using YandexSDK.Scripts;

namespace Anecdotes
{
    public class SaveData
    {
        public static SaveData Instance { get; private set; }

        public event Action DataChanged;
        public string Language { get; private set; }

        static SaveData()
        {
            Instance = new SaveData();
        }

        private SaveData()
        {
            Language = YandexGamesManager.GetLanguageString();
        }

        public void SetLanguage(string lan)
        {
            Language = lan;
            DataChanged?.Invoke();
        }
    }
}