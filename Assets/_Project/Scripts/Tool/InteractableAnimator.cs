using Tools;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableAnimator : MonoBehaviour, IInteractableBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string interactionTriggerName;
    [SerializeField] private Interactable interactable;

    private bool isPlayingAnimation;
    
    public void ExecuteBehaviour()
    {
        if(!isPlayingAnimation)
        {
            isPlayingAnimation = true;
            animator.SetTrigger(Animator.StringToHash(interactionTriggerName));
        }
    }

    public void FinishBehaviour()
    {
        isPlayingAnimation = false;
        interactable.FinishWorking();
    }
}
