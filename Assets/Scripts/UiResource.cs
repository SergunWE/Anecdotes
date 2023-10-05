using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Anecdotes
{
    public class UiResource : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        
        [SerializeField, Space] private VisualTreeAsset incomingMessage;
        [SerializeField] private VisualTreeAsset sentMessage;

        [SerializeField, Space] private JokeContainer jokeContainer;

        private MainPageCustomControl _control;

        private void Awake()
        {
            _control = uiDocument.rootVisualElement.Q<MainPageCustomControl>();
            _control.Init(incomingMessage, sentMessage, jokeContainer);
        }

        private void OnEnable()
        {
            GameEventManager.Instance.DataChanged += OnDataChanged;
            GameEventManager.Instance.Reaction += StartNewJoke;
        }
        
        private void OnDisable()
        {
            GameEventManager.Instance.DataChanged -= OnDataChanged;
            GameEventManager.Instance.Reaction -= StartNewJoke;
        }

        private void OnDataChanged()
        {
            _control.UpdateJokesText();
        }

        private void Start()
        {
            FullscreenAdManager.Instance.AdClosed += StartNewJoke;
            StartNewJoke();
        }
        
        private void StartNewJoke()
        {
            if (FullscreenAdManager.Instance.CanShowAd())
            {
                FullscreenAdManager.Instance.ShowAd();
            }
            else
            {
                StopCoroutine(ShowJokeCoroutine());
                StartCoroutine(ShowJokeCoroutine());
                
            }
        }

        private IEnumerator ShowJokeCoroutine()
        {
            _control.CreateNewJoke();
            yield return new WaitForSeconds(1f);
            _control.ShowIncomingMessage();
            yield return new WaitForSeconds(1f);
            _control.ShowSentMessage();
        }
    }
}