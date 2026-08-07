using System;
using UnityEngine;
using GameManager;
using RTLTMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro objectiveText;
    [SerializeField] private ScenarioManager scenarioManager;
    
    private void OnEnable()
    {
        scenarioManager.OnStepChange += UpdateObjectiveText;
    }

    private void OnDisable()
    {
        scenarioManager.OnStepChange -= UpdateObjectiveText;
    }

    private void UpdateObjectiveText(Step step, int stepIndex)
    {
        objectiveText.text = step.ObjectiveText;
    }
}
