using UnityEngine;

namespace Anecdotes
{
    [CreateAssetMenu(menuName = "Joke")]
    public class JokeSo : ScriptableObject
    {
        [SerializeField, Multiline] private string ruJoke;
        [SerializeField, Multiline] private string enJoke;

        public string GetJoke()
        {
            return SaveData.Instance.Language switch
            {
                "ru" => ruJoke,
                "en" => enJoke,
                _ => enJoke
            };
        }
    }
}