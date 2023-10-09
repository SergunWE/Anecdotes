using System.Collections.Generic;
using UnityEngine;

namespace Anecdotes
{
    public class JokeContainer : MonoBehaviour
    {
        [SerializeField] private List<JokeSo> jokes;

        private const string IndexKey = "IndexKey";

        private int _index;

        private void Awake()
        {
            _index = PlayerPrefs.GetInt(IndexKey, 0);
        }

        public JokeSo GetRandomJoke()
        {
            int index = _index;

            PlayerPrefs.SetInt(IndexKey, _index);
            PlayerPrefs.Save();

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