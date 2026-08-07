using System;
using System.Linq;
using Tools;
using UnityEngine;

namespace GameManager
{
    public class ScenarioManager : MonoBehaviour
    {
        [SerializeField] private Step firstStep;
        [SerializeField] private ToolType noToolType;
        public ToolType NoToolType => noToolType;
        private Step currentStep;

        [SerializeField] private GameObject player;

        [SerializeField] private Equipper playerEquipper;
        [SerializeField] private CutsceneManager cutsceneManager;
        public Equipper PlayerEquipper => playerEquipper;

        [SerializeField] private Tool[] tools;
        [SerializeField] private Part[] parts;

        private int currentStepIndex = 1;
        public event Action<Step, int> OnStepChange;

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
            currentStepIndex++;
            // OnStepChange?.Invoke(currentStep);
            UpdateGame();
        }

        private void UpdateGame()
        {
            OnStepChange?.Invoke(currentStep, currentStepIndex);

            if (currentStep is CutsceneStep step)
            {
                cutsceneManager.PlayCutscene(step.Cutscene);
            }
        }

        public bool IsCurrentInteraction(Interactable interactable)
        {
            return currentStep.CanInteract(interactable, this);
        }

        public bool CanUseTool(Tool tool, Part part)
        {
            if (currentStep is not PartInteractionStep step) return false;

            return step.CanUseTool(tool, part);
        }

        private void OnPlayerToolEquipped(Tool tool)
        {
            if (currentStep is not EquipToolStep step)
                throw new ArgumentException("This step shouldn't allow tool equipment");
            
            if (tool.ToolType == step.RequiredTool)
                GoToNextStep();
        }

        public void ExecutePartBehaviours()
        {
            var step = currentStep as PartInteractionStep;
            var targetPart = parts.FirstOrDefault(part => part.PartType == step.TragetPart);

            if(step.RequiredTool == NoToolType){
                targetPart.WorkWithoutTool();
                return;
            }
            targetPart.FinishWorking();
        }

        public void FinalizeStep()
        {
            GoToNextStep();
        }

        public bool DoesStepRequireTool()
        {
            if (currentStep is not PartInteractionStep step) return false;

            return step.RequiredTool != NoToolType;
        }
    }
}