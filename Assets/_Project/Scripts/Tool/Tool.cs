using System;
using GameManager;
using UnityEngine;
using VisualEffects;

namespace Tools
{
    public abstract class Tool : Interactable
    {
        [SerializeField] private ToolType toolType;
        public ToolType ToolType => toolType;

        [SerializeField] protected Transform holdingPoint;
        public Transform HoldingPoint => holdingPoint;
        
        [SerializeField] protected Vector3 holdingRotation;
        public Vector3 HoldingRotation => holdingRotation;
        
        public abstract void Use(Part targetPart);

        public virtual void StopUse()
        {
            
        }

        private void OnEnable()
        {
            scenarioManager.OnStepChange += EnableHighlight;
        }

        private void OnDisable()
        {
            scenarioManager.OnStepChange -= EnableHighlight;
        }

        private void EnableHighlight(Step step)
        {
            if (step is not EquipToolStep)
            {
                highlighter.enabled = false;
                interactionPrompt.DisableInteractionUI();
                
                return;
            }

            var s = step as EquipToolStep;

            if (s.RequiredTool == toolType)
            {
                highlighter.enabled = true;
            }
        }

        public void BringToHand(Vector3 handPosition)
        {
            transform.MoveChildTo(holdingPoint, handPosition);
        }

        public void EnableInteraction()
        {
            interactionPrompt.EnableInteractionUI();
        }
    }
}