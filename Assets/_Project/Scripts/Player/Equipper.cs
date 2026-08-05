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
        currentTool = tool;
        Debug.Log(tool.ToolType);
        OnToolEquipped?.Invoke(tool);
    }
}
