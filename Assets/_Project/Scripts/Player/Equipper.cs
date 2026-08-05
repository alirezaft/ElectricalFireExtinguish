using System;
using Tools;
using UnityEngine;

public class Equipper : MonoBehaviour
{
    [SerializeField] private ToolType noToolEnum;
    [SerializeField] private Transform handPosition;
    private Tool currentTool;
    public Tool CurrentTool => currentTool;
    
    public event Action<Tool> OnToolEquipped;

    public void EquipTool(Tool tool, Transform hand)
    {
        tool.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        PutInHand(tool);
        
        currentTool = tool;
        OnToolEquipped?.Invoke(tool);
    }

    public void PutInHand(Tool tool)
    {
        tool.transform.MoveChildTo(tool.HoldingPoint, handPosition.position);
        tool.transform.rotation = Quaternion.Euler(tool.HoldingRotation);
        tool.transform.parent = handPosition;
    }
}
