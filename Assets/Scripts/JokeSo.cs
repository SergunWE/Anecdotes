using UnityEngine;

namespace Anecdotes
{
    [CreateAssetMenu(menuName = "Joke")]
    public class JokeSo : ScriptableObject
    {
        [SerializeField, TextArea(10,1000)] private string ruJoke;

        public string GetJoke => ruJoke;
    }
}