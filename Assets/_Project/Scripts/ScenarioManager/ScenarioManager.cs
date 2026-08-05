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

        private void Awake()
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
            UpdateGame();
        }

        private void UpdateGame()
        {
            OnStepChange?.Invoke(currentStep);

            var requiredTool = tools.FirstOrDefault(tool => tool.ToolType == ((EquipToolStep)currentStep).RequiredTool);
            
            if (requiredTool is null)
                throw new NullReferenceException("Step required tool was not found in scenario manager tool list");

            requiredTool.GetComponent<Highlighter>().enabled = true;
        }

        public bool IsCurrentInteraction(Interactable interactable)
        {
            return currentStep.CanInteract(interactable, this);
        }

        private void OnPlayerToolEquipped(Tool tool)
        {
            playerEquipper.CurrentTool.GetComponent<Highlighter>().enabled = false;
        }
    }
}