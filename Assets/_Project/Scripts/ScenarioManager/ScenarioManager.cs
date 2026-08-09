using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using GameManager.Steps;
using Player.Control;
using Interactables;
using Interactables.Parts;
using Interactables.Tools;
using Player;
using UI;
using Material = Interactables.Tools.Material;

namespace GameManager
{
    public class ScenarioManager : MonoBehaviour
    {
        public static ScenarioManager instance { get; private set; }

        [SerializeField] private Step firstStep;
        [SerializeField] private ToolType noToolType;
        public ToolType NoToolType => noToolType;
        private Step currentStep;

        [SerializeField] private GameObject player;

        [SerializeField] private Equipper playerEquipper;
        [SerializeField] private CutsceneManager cutsceneManager;
        
        [SerializeField] private GameObject endUI;
        [SerializeField] private EndUIText endUIText;
        
        public Equipper PlayerEquipper => playerEquipper;

        [SerializeField] private List<Tool> tools;
        [SerializeField] private List<Part> parts;

        private int currentStepIndex = 1;
        public event Action<Step, int> OnStepChange;
        public event Action OnScenarioFinish;


        public void Awake()
        {
            if(instance is not null && instance != this)
                Destroy(this);
            
            if (instance is null)
                instance = this;
        }

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
            if(currentStep is not EndStep)
                ApplyStep();
            else
            {
                Debug.Log("FINISH!!");
                FinishScenario();
            }
        }

        private void ApplyStep()
        {
            OnStepChange?.Invoke(currentStep, currentStepIndex);

            if (currentStep is CutsceneStep step)
            {
                cutsceneManager.PlayCutscene(step.Cutscene);
            }
        }

        private void FinishScenario()
        {
            OnScenarioFinish?.Invoke();
            ShowEndUI();
        }

        private void ShowEndUI()
        {
            endUI.SetActive(true);
            endUIText.SetText(currentStep.ObjectiveText);
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

            if(step.RequiredTool == NoToolType || PlayerEquipper.CurrentTool is Material){
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

        public void LockPlayerMovementAndLook()
        {
            player.GetComponent<PlayerMovementController>().enabled = false;
            player.GetComponent<PlayerLookController>().enabled = false;
            player.GetComponent<PlayerInteractionController>().enabled = false;
        }
        
        public void UnlockPlayerMovementAndLook()
        {
            player.GetComponent<PlayerMovementController>().enabled = true;
            player.GetComponent<PlayerLookController>().enabled = true;
            player.GetComponent<PlayerInteractionController>().enabled = true;
        }

        public void RegisterInteractable(Part part)
        {
            parts.Add(part);
        }
    }
}