using System;
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
            SaveData.Instance.DataChanged += OnDataChanged;
        }
        
        private void OnDisable()
        {
            SaveData.Instance.DataChanged -= OnDataChanged;
        }

        private void OnDataChanged()
        {
            _control.ShowJoke();
        }
    }
}