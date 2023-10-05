using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using YandexSDK.Scripts;

namespace Anecdotes
{
    public class MainPageCustomControl : VisualElement
    {
        private VisualTreeAsset _incomingMessageAsset;
        private VisualTreeAsset _sentMessageAsset;
        private JokeContainer _jokeContainer;

        private IncomingMessageCustomControl _currentIncoming;
        private SentMessageCustomControl _currentSent;

        private ScrollView _scrollView;
        private VisualElement _scrollContainer;

        private ValueAnimation<float> _currentAnimation;

        private Label _contactText;
        private VisualElement _ruButton;
        private VisualElement _enButton;

        public new class UxmlFactory : UxmlFactory<MainPageCustomControl>
        {
        }

        public void Init(VisualTreeAsset incomingMessage, VisualTreeAsset sentMessage, JokeContainer jokeContainer)
        {
            _incomingMessageAsset = incomingMessage;
            _sentMessageAsset = sentMessage;
            _jokeContainer = jokeContainer;

            _scrollView = this.Q<ScrollView>();
            _scrollContainer = _scrollView.Q<VisualElement>("unity-content-container");
            _scrollView.Clear();

            _contactText = this.Q<Label>("ContactText");
            _ruButton = this.Q<VisualElement>("Ru");
            _enButton = this.Q<VisualElement>("En");

            _contactText.text = SaveData.Instance.Language == "ru" ? "Твой друг" : "Your friend";
            _ruButton.RegisterCallback<ClickEvent, string>(OnLanguageButtonClicked, "ru");
            _enButton.RegisterCallback<ClickEvent, string>(OnLanguageButtonClicked, "en");

            //_scrollContainer.RegisterCallback<GeometryChangedEvent>(Callback);
        }

        private void OnLanguageButtonClicked(ClickEvent evt, string lan)
        {
            SaveData.Instance.SetLanguage(lan);
        }

        private void Callback(GeometryChangedEvent evt)
        {
            _currentAnimation?.Stop();
            _currentAnimation?.Recycle();

            // _currentAnimation = _scrollView.experimental.animation.Start(_scrollView.verticalScroller.value,
            //         _scrollView.verticalScroller.highValue, 400, (vs,
            //             value) =>
            //         {
            //             _scrollView.verticalScroller.value = value;
            //         })
            //     .Ease(Easing.InOutCubic).KeepAlive();

            _scrollView.verticalScroller.value = _scrollView.verticalScroller.highValue;
            _scrollContainer.UnregisterCallback<GeometryChangedEvent>(Callback);
        }

        public void CreateNewJoke()
        {
            _currentIncoming = _incomingMessageAsset.Instantiate().Q<IncomingMessageCustomControl>();
            _currentSent = _sentMessageAsset.Instantiate().Q<SentMessageCustomControl>();
            
            _currentIncoming.Init(_jokeContainer.GetRandomJoke());
        }

        public void ShowIncomingMessage()
        {
            _scrollContainer.RegisterCallback<GeometryChangedEvent>(Callback);
            _scrollView.Add(_currentIncoming);
        }

        public void ShowSentMessage()
        {
            _scrollContainer.RegisterCallback<GeometryChangedEvent>(Callback);
            _scrollView.Add(_currentSent);
        }

        public void UpdateJokesText()
        {
            _contactText.text = SaveData.Instance.Language == "ru" ? "Твой друг" : "Your friend";
            
            var jokesList = _scrollView.Query<IncomingMessageCustomControl>().ToList();
            foreach (var joke in jokesList)
            {
                joke.UpdateText();
            }
        }

        private VisualElement GetSpaceElement(int height)
        {
            return new VisualElement
            {
                style =
                {
                    height = height
                }
            };
        }
    }
}