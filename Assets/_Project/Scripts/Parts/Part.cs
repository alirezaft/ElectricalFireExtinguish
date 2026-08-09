using System.Linq;
using GameManager.Steps;
using Interactables.Behaviours;
using UnityEngine;

namespace Interactables.Parts
{
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

        private void EnableHighlight(Step step, int stepIndex)
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

        public void WorkWithoutTool()
        {
            highlighter.enabled = false;
            ExecuteBehaviours();
            scenarioManager.FinalizeStep();
            PlaySound();
        }

        public override void FinishWorking()
        {
            highlighter.enabled = false;
            ExecuteBehaviours();
            scenarioManager.FinalizeStep();
            interactableBehaiours.FirstOrDefault(behaviour => behaviour is DestroySelfBehaviour)
                ?.ExecuteBehaviour();
            PlaySound();
        }
    }
}