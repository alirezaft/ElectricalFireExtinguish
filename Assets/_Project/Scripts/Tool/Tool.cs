using System;
using GameManager.Steps;
using Interactables.Parts;
using UnityEngine;
using Utils;

namespace Interactables.Tools
{
    public abstract class Tool : Interactable
    {
        [SerializeField] private ToolType toolType;
        public ToolType ToolType => toolType;

        [SerializeField] protected Transform holdingPoint;
        public Transform HoldingPoint => holdingPoint;
        
        [SerializeField] protected Vector3 holdingRotation;
        public Vector3 HoldingRotation => holdingRotation;

        [SerializeField] private Transform restingPlace;
        public Transform RestingPlace => restingPlace;

        [SerializeField] public Vector3 restingRotation;
        public Vector3 RestingRotation => restingRotation;

        public event Action<Tool> OnEquip;
        public event Action<Tool> OnUnequip;
        
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

        private void EnableHighlight(Step step, int stepIndex)
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

        public void FireOnEquip()
        {
            OnEquip?.Invoke(this);
        }

        public void FireOnUnequip()
        {
            OnUnequip?.Invoke(this);
        }
    }
}