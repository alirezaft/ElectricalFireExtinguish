using Parts;
using Tools;
using UnityEngine;

namespace GameManager
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
            if (interactable is not Part) return false;

            var part = interactable as Part;
            
            if (part.PartType != targetPart) return false;
            if (requiredTool != manager.PlayerEquipper.CurrentTool.ToolType) return false;

            return true;
        }
    }
}