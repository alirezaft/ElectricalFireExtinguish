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

            var requiredTool = tools.FirstOrDefault(tool => tool.ToolType == currentStep.RequiredTool);
            
            if (requiredTool is null)
                throw new NullReferenceException("Step required tool was not found in scenario manager tool list");

            requiredTool.GetComponent<Highlighter>().enabled = true;
        }

        public bool IsCurrentInteraction(Interactable tool)
        {
            // return tool.ToolType == currentStep.RequiredTool && player.GetComponent<Equipper>().CurrentTool == null;
            return true;
        }

        private void OnPlayerToolEquipped(Tool tool)
        {
            playerEquipper.CurrentTool.GetComponent<Highlighter>().enabled = false;
            
            
            var currentPart = parts.FirstOrDefault(part => part.PartType == currentStep.TargetObject);
            
        }
    }
}