using System.Collections.Generic;
using UnityEngine;

namespace Anecdotes
{
    public class JokeContainer : MonoBehaviour
    {
        [SerializeField] private List<JokeSo> jokes;

        public JokeSo GetRandomJoke()
        {
            return jokes[Random.Range(0, jokes.Count - 1)];
        }
    }
}