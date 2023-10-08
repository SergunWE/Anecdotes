using System;
using System.Collections.Generic;
using UnityEngine;
using YandexSDK.Scripts;
using Random = UnityEngine.Random;

namespace Anecdotes
{
    public class JokeContainer : MonoBehaviour
    {
        [SerializeField] private List<JokeSo> jokes;

        private const string IndexKey = "IndexKey";
        private const string CountKey = "CountKey";

        private int _index;
        private int _count;

        private void Awake()
        {
            _index = PlayerPrefs.GetInt(IndexKey, 0);
            _count = PlayerPrefs.GetInt(CountKey, 0);
        }

        public JokeSo GetRandomJoke()
        {
            int index = _index;

            PlayerPrefs.SetInt(IndexKey, _index);
            PlayerPrefs.Save();
#if !DEBUG
            YandexGamesManager.SetToLeaderboard(_count);
            _count++;
#endif

            if (_index >= jokes.Count - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }

            return jokes[index];
        }
    }
}