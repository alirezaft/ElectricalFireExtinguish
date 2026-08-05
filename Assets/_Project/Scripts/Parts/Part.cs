using GameManager;
using Parts;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

public class Part : Interactable
{
    [SerializeField] private PartType partType;
    public PartType PartType => partType; 
    
    [SerializeField] private Transform interactionPoint;
    public Transform InteractionPoint => interactionPoint;
    
    private void OnEnable()
    {
        scenarioManager.OnStepChange += EnableHighlight;
    }

    private void OnDisable()
    {
        scenarioManager.OnStepChange -= EnableHighlight;
    }

    private void EnableHighlight(Step step)
    {
        if (step is not PartInteractionStep)
        {
            highlighter.enabled = false;
            interactionPrompt.DisableInteractionUI();
                
            return;
        }

        var s = step as PartInteractionStep;

        if (s.TragetPart == PartType)
        {
            highlighter.enabled = true;
        }
    }
}
