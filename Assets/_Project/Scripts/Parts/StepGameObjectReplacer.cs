using System;
using GameManager;
using UnityEngine;

public class StepGameObjectReplacer : GameObjectReplacer
{
    [SerializeField] private int targetStepIndex = 0;

    private void Start()
    {
        ScenarioManager.instance.OnStepChange += Replace;
    }

    private void Replace(Step step, int targetIndex)
    {
        if (targetIndex == targetStepIndex)
        {
            Debug.Log("REPLACE IT");
            Replace();
        }
    }
}
