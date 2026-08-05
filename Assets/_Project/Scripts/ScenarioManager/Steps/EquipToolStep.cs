using Tools;
using UnityEngine;

namespace GameManager
{
    [CreateAssetMenu(menuName = ("Game/Step/Equip Tool Step"), fileName = "NewEquipToolStep")]
    public class EquipToolStep : Step
    {
        [SerializeField] private ToolType requiredTool;
        public ToolType RequiredTool => requiredTool;

        public override bool CanInteract(Interactable interactable, ScenarioManager manager)
        {
            if (interactable is not Tool) return false;
            
            var tool = interactable as Tool;
            if (tool.ToolType != requiredTool) return false;
            
            return true;
        }
    }
}