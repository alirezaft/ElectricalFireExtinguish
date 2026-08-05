using Tools;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string interactionTriggerName;
    [SerializeField] private Interactable interactable;

    private bool isPlayingAnimation;
    
    public void PlayAnimation()
    {
        if(!isPlayingAnimation)
        {
            isPlayingAnimation = true;
            animator.SetTrigger(Animator.StringToHash(interactionTriggerName));
        }
    }

    public void OnAnimationFinished()
    {
        isPlayingAnimation = false;
        interactable.FinishWorking();
    }
}
