using UnityEngine;

namespace Interactables.Behaviours
{
    public class InteractableAnimator : MonoBehaviour, IInteractableBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string interactionTriggerName;
        [SerializeField] private Interactable interactable;

        private bool isPlayingAnimation;

        public void ExecuteBehaviour()
        {
            if (!isPlayingAnimation)
            {
                animator.enabled = true;
                isPlayingAnimation = true;
                animator.SetTrigger(Animator.StringToHash(interactionTriggerName));
            }
        }

        public void AnimationFinished()
        {
            isPlayingAnimation = false;
        }

        public void FinishBehaviour()
        {
            interactable.FinishWorking();
            isPlayingAnimation = false;
            // animator.enabled = false;
        }
    }
}
