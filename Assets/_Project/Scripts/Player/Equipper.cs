using System;
using Tools;
using Unity.VisualScripting;
using UnityEngine;

public class Equipper : MonoBehaviour
{
    [SerializeField] private ToolType noToolEnum;
    [SerializeField] private Transform handPosition;
    private Tool currentTool;
    public Tool CurrentTool => currentTool;
    
    public event Action<Tool> OnToolEquipped;

    public void EquipTool(Tool tool)
    {
        if (CurrentTool is not null)
        {
            DetachToolFromHand();
            CurrentTool.transform.SwapTransformWith(tool.transform);
        }
        
        tool.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        PutInHand(tool);
        
        currentTool = tool;
        OnToolEquipped?.Invoke(tool);
    }

    private void DetachToolFromHand()
    {
        CurrentTool.transform.parent = null;
        CurrentTool.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void PutInHand(Tool tool)
    {
        tool.transform.SetParent(handPosition, false);
        tool.transform.MoveChildTo(tool.HoldingPoint, handPosition.position);
        tool.transform.rotation = Quaternion.Euler(tool.HoldingRotation);
        
        // tool.transform.SetParent(handPosition);
        //
        // tool.transform.localPosition = -tool.HoldingPoint.localPosition;
        // tool.transform.localRotation = Quaternion.Inverse(tool.transform.localRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(handPosition.position, 0.1f);
    }
}
