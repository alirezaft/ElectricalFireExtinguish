using System;
using Interactables;
using UnityEngine;

namespace GameManager.Steps
{
    public abstract class Step : ScriptableObject
    {
        [SerializeField] private Step nextStep;
        public Step NextStep => nextStep;
        
        [SerializeField] private string objectiveText;
        public string ObjectiveText => objectiveText;

        public abstract bool CanInteract(Interactable interactable, ScenarioManager manager);

        public event Action OnStepStart;
        public event Action OnStepComplete;
    }
}