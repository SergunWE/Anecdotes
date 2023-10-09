using Anecdotes;
using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip incomingMessage;
        [SerializeField] private AudioClip sentMessage;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameEventManager.Instance.MessageIncoming += MessageIncoming;
            GameEventManager.Instance.Reaction += Reaction;
        }

        private void OnDisable()
        {
            GameEventManager.Instance.MessageIncoming -= MessageIncoming;
            GameEventManager.Instance.Reaction -= Reaction;
        }

        private void Reaction()
        {
            _audioSource.PlayOneShot(sentMessage);
        }

        private void MessageIncoming()
        {
            _audioSource.PlayOneShot(incomingMessage);
        }
    }
}