using System;
using GameManager;
using UnityEngine;
using VisualEffects;

namespace Tools
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractionPrompt interactionPrompt;
        public ScenarioManager scenarioManager;
        [SerializeField] protected Highlighter highlighter;
        [SerializeField] protected AudioClip useAudio;
        
        protected IInteractableBehaviour[] interactableBehaiours;


        private void Awake()
        {
            interactableBehaiours = GetComponents<IInteractableBehaviour>();
            if(scenarioManager is null)
                scenarioManager = ScenarioManager.instance;
        }

        public virtual void Focus()
        {
            interactionPrompt.EnableInteractionUI();
        }

        public virtual void Unfocus()
        {
            interactionPrompt.DisableInteractionUI();
        }

        public void ExecuteBehaviours()
        {
            foreach (var behaviour in interactableBehaiours)
            {
                if (behaviour is DestroyInteractableBehaviour)
                    continue;
                
                behaviour.ExecuteBehaviour();
            }
        }

        protected void PlaySound()
        {
            if(useAudio != null)
                AudioSource.PlayClipAtPoint(useAudio, transform.position);
        }

        public abstract void FinishWorking();
    }
}