using System;
using GameManager;
using UnityEngine;

namespace Tools
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractionPrompt interactionPrompt;
        [SerializeField] protected ScenarioManager scenarioManager;
        
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