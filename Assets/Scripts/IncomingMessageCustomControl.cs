using System;
using UnityEngine.UIElements;

namespace Anecdotes
{
    public class IncomingMessageCustomControl : VisualElement
    {
        private Label _incomingText;
        private JokeSo _jokeSo;
        private Label _timeText;
        private DateTime _time;
        
        public new class UxmlFactory : UxmlFactory<IncomingMessageCustomControl>
        {
        }

        public void Init(JokeSo jokeSo)
        {
            _jokeSo = jokeSo;
            _time = DateTime.Now;
            _incomingText ??= this.Q<Label>("IncomingMessageText");
            _timeText ??= this.Q<Label>("TimeText");
            UpdateText();
        }

        public void UpdateText()
        {
            _incomingText.text = _jokeSo.GetJoke();
            _timeText.text = _time.ToShortTimeString();
        }
    }
}