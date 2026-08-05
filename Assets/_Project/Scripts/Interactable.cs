using System;
using GameManager;
using UnityEngine;
using VisualEffects;

namespace Tools
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractionPrompt interactionPrompt;
        [SerializeField] protected ScenarioManager scenarioManager;
        [SerializeField] protected Highlighter highlighter;

        
        public virtual void Focus()
        {
            interactionPrompt.EnableInteractionUI();
        }

        public virtual void Unfocus()
        {
            interactionPrompt.DisableInteractionUI();
        }
    }
}