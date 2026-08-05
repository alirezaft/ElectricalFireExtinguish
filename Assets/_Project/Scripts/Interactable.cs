using UnityEngine;

namespace Tools
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractionPrompt interactionPrompt;

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