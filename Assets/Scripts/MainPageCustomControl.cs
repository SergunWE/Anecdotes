using UnityEngine.UIElements;

namespace Anecdotes
{
    public class MainPageCustomControl : VisualElement
    {
        private VisualTreeAsset _incomingMessage;
        private VisualTreeAsset _sentMessage;
        private JokeContainer _jokeContainer;

        private VisualElement _currentIncoming;
        private VisualElement _currentSent;
        private JokeSo _currentJoke;
        
        public new class UxmlFactory : UxmlFactory<MainPageCustomControl>
        {
        }
        
        public void Init(VisualTreeAsset incomingMessage, VisualTreeAsset sentMessage, JokeContainer jokeContainer)
        {
            _incomingMessage = incomingMessage;
            _sentMessage = sentMessage;
            _jokeContainer = jokeContainer;
        }

        public void CreateNewJoke()
        {
            
        }

        public void ShowJoke()
        {
            
        }
        
    }
}