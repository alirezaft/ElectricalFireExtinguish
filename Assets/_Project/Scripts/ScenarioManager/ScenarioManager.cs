using System;
using System.Linq;
using Tools;
using UnityEngine;
using VisualEffects;

namespace GameManager
{
    public class ScenarioManager : MonoBehaviour
    {
        [SerializeField] private Step firstStep;
        private Step currentStep;

        [SerializeField] private GameObject player;

        [SerializeField] private Equipper playerEquipper;
        public Equipper PlayerEquipper => playerEquipper;

        [SerializeField] private Tool[] tools;
        [SerializeField] private Part[] parts;

        public event Action<Step> OnStepChange;

        private void Start()
        {
            currentStep = firstStep;
            UpdateGame();
        }

        private void OnEnable()
        {
            player.GetComponent<Equipper>().OnToolEquipped += OnPlayerToolEquipped;
        }

        private void OnDisable()
        {
            player.GetComponent<Equipper>().OnToolEquipped -= OnPlayerToolEquipped;
        }

        public void GoToNextStep()
        {
            currentStep = currentStep.NextStep;
            OnStepChange?.Invoke(currentStep);
            UpdateGame();
        }

        private void UpdateGame()
        {
            OnStepChange?.Invoke(currentStep);
            
            
        }

        public bool IsCurrentInteraction(Interactable interactable)
        {
            return currentStep.CanInteract(interactable, this);
        }

        private void OnPlayerToolEquipped(Tool tool)
        {
            if (currentStep is not EquipToolStep step)
                throw new ArgumentException("This step shouldn't allow tool equipment");
            
            if (tool.ToolType == step.RequiredTool)
                GoToNextStep();
        }
    }
}