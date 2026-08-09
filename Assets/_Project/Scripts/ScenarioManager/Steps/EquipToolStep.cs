using Interactables;
using Interactables.Tools;
using UnityEngine;

namespace GameManager.Steps
{
    [CreateAssetMenu(menuName = ("Game/Step/Equip Tool Step"), fileName = "NewEquipToolStep")]
    public class EquipToolStep : Step
    {
        [SerializeField] private ToolType requiredTool;
        public ToolType RequiredTool => requiredTool;

        public override bool CanInteract(Interactable interactable, ScenarioManager manager)
        {
            if (interactable is not Tool tool) return false;
            
            if (tool.ToolType != requiredTool) return false;
            
            return true;
        }
    }
}