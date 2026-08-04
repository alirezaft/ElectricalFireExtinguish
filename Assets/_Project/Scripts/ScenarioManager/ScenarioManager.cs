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
        
        [SerializeField] private Tool[] tools;
        [SerializeField] private GameObject[] parts;

        public event Action<Step> OnStepChange;

        private void Awake()
        {
            currentStep = firstStep;
            UpdateGame();
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
        
    }
}