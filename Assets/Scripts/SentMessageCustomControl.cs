using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Anecdotes
{
    public class SentMessageCustomControl : VisualElement
    {
        private VisualElement _reactionRoot;
        private Label _timeText;

        private readonly List<VisualElement> _reactions = new();
        
        public new class UxmlFactory : UxmlFactory<SentMessageCustomControl>
        {
        }

        public SentMessageCustomControl()
        {
            RegisterCallback<AttachToPanelEvent>(Attach);
        }

        private void Attach(AttachToPanelEvent evt)
        {
            _reactionRoot = this.Q<VisualElement>("ReactionRoot");
            _timeText ??= this.Q<Label>("TimeText");

            foreach (var child in _reactionRoot.Children())
            {
                _reactions.Add(child);
                child.RegisterCallback<ClickEvent, VisualElement>(OnReactionClicked, child);
            }

            _timeText.text = "";
        }

        private void OnReactionClicked(ClickEvent evt, VisualElement element)
        {
            
            _timeText.text = DateTime.Now.ToShortTimeString();
            
            GameEventManager.Instance.Reaction?.Invoke();

            foreach (var reaction in _reactions)
            {
                if (reaction != element)
                {
                    reaction.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
                }
                reaction.UnregisterCallback<ClickEvent, VisualElement>(OnReactionClicked);
            }
        }
    }
}