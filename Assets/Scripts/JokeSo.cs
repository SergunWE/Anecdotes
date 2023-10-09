using UnityEngine;

namespace Anecdotes
{
    [CreateAssetMenu(menuName = "Joke")]
    public class JokeSo : ScriptableObject
    {
        [SerializeField, Multiline] private string ruJoke;

        public string GetJoke => ruJoke;
    }
}