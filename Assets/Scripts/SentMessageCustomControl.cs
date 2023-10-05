using System;
using UnityEngine.UIElements;

namespace Anecdotes
{
    public class SentMessageCustomControl : VisualElement
    {
        private VisualElement _like;
        private VisualElement _dislike;
        private Label _timeText;
        
        public new class UxmlFactory : UxmlFactory<SentMessageCustomControl>
        {
        }

        public SentMessageCustomControl()
        {
            RegisterCallback<AttachToPanelEvent>(Attach);
        }

        private void Attach(AttachToPanelEvent evt)
        {
            _like = this.Q<VisualElement>("Like");
            _dislike = this.Q<VisualElement>("Dislike");
            _timeText ??= this.Q<Label>("TimeText");
            
            _like?.RegisterCallback<ClickEvent, VisualElement>(OnReactionClicked, _dislike);
            _dislike?.RegisterCallback<ClickEvent, VisualElement>(OnReactionClicked, _like);

            _timeText.text = "";
        }

        private void OnReactionClicked(ClickEvent evt, VisualElement element)
        {
            element.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
            _timeText.text = DateTime.Now.ToShortTimeString();
            
            GameEventManager.Instance.Reaction?.Invoke();
            
            _like.UnregisterCallback<ClickEvent, VisualElement>(OnReactionClicked);
            _dislike.UnregisterCallback<ClickEvent, VisualElement>(OnReactionClicked);
        }
    }
}