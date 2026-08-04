using GameManager;
using Tools;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private ScenarioManager scenarioManager;

    public void AttemptInteraction(Tool tool)
    {
        if(scenarioManager.IsCurrentInteraction(tool))
            tool.GetComponent<InteractionPrompt>().EnableInteractionUI();
    }

    public void CancelInteractionAttempt(Tool tool)
    {
        tool.GetComponent<InteractionPrompt>().DisableInteractionUI();
    }
}
