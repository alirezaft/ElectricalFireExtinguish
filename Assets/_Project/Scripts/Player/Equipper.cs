using System;
using Tools;
using UnityEngine;

public class Equipper : MonoBehaviour
{
    [SerializeField] private ToolType noToolEnum;
    private Tool currentTool;
    public Tool CurrentTool => currentTool;
    
    public event Action<Tool> OnToolEquipped;

    public void EquipTool(Tool tool)
    {
        tool.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        currentTool = tool;
        Debug.Log(tool.ToolType);
        OnToolEquipped?.Invoke(tool);
    }
}
