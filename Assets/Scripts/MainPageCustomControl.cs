using UnityEngine.UIElements;

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
        }

        private void Callback(GeometryChangedEvent evt)
        {
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
            GameEventManager.Instance.MessageIncoming?.Invoke();
        }

        public void ShowSentMessage()
        {
            _scrollContainer.RegisterCallback<GeometryChangedEvent>(Callback);
            _scrollView.Add(_currentSent);
        }
    }
}