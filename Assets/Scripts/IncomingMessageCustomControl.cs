using UnityEngine.UIElements;

namespace Anecdotes
{
    public class IncomingMessageCustomControl : VisualElement
    {
        private Label _incomingText;
        private JokeSo _jokeSo;
        
        public new class UxmlFactory : UxmlFactory<IncomingMessageCustomControl>
        {
        }

        public void Init(JokeSo jokeSo)
        {
            _jokeSo = jokeSo;
            UpdateText();
        }

        public void UpdateText()
        {
            _incomingText ??= this.Q<Label>("IncomingMessageText");
            _incomingText.text = _jokeSo.GetJoke();
        }
    }
}