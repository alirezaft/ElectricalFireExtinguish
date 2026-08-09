using Interactables;
using UnityEngine;

namespace GameManager{
public class InteractionManager : MonoBehaviour
{
    [SerializeField] private ScenarioManager scenarioManager;

    public bool AttemptInteraction(Interactable interactable)
    {
        if (scenarioManager.IsCurrentInteraction(interactable))
        {
            interactable.Focus();
            return true;
        }

        return false;
    }

    public void CancelInteractionAttempt(Interactable interactable)
    {
        interactable.Unfocus();
    }
}
}