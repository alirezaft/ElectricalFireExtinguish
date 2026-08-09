using Interactables.Parts;
using Interactables;
using Interactables.Parts;
using Interactables.Tools;
using UnityEngine;

namespace GameManager.Steps
{
    [CreateAssetMenu(menuName = "Game/Step/Part Interaction Step", fileName = "NewPartInteractionStep")]
    public class PartInteractionStep : Step
    {
        [SerializeField] private ToolType requiredTool;
        public ToolType RequiredTool => requiredTool;

        [SerializeField] private PartType targetPart;
        public PartType TragetPart => targetPart;

        public override bool CanInteract(Interactable interactable, ScenarioManager manager)
        {
            if (interactable is not Part part) return false;

            if (part.PartType != targetPart) return false;
            if (requiredTool != manager.NoToolType && requiredTool != manager.PlayerEquipper.CurrentTool.ToolType) return false;

            return true;
        }

        public bool CanUseTool(Tool tool, Part part)
        {
            if (RequiredTool != tool.ToolType) return false;
            if (TragetPart != part.PartType) return false;

            return true;
        }
    }
}