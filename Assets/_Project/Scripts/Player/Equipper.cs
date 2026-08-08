using System;
using Tools;
using Unity.VisualScripting;
using UnityEngine;

public class Equipper : MonoBehaviour
{
    [SerializeField] private ToolType noToolEnum;
    [SerializeField] private Transform handPosition;
    [SerializeField] private AudioClip toolEquipSound;
    private Tool currentTool;
    public Tool CurrentTool => currentTool;
    
    public event Action<Tool> OnToolEquipped;

    public void EquipTool(Tool tool)
    {
        AudioSource.PlayClipAtPoint(toolEquipSound, transform.position);
        if (CurrentTool is not null)
        {
            CurrentTool.FireOnUnequip();
            DetachCurrentToolFromHand();
            PutCurrentToolDown();
        }
        
        tool.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        PutInHand(tool);
        
        currentTool = tool;
        
        
        OnToolEquipped?.Invoke(tool);
        tool.FireOnEquip();
    }

    private void DetachCurrentToolFromHand()
    {
        CurrentTool.transform.parent = null;
        CurrentTool.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    private void PutCurrentToolDown()
    {
        CurrentTool.transform.position = CurrentTool.RestingPlace.position;
        CurrentTool.transform.rotation = Quaternion.Euler(CurrentTool.RestingRotation);
    } 

    public void PutInHand(Tool tool)
    {
        tool.transform.SetParent(handPosition, false);
        tool.transform.MoveChildTo(tool.HoldingPoint, handPosition.position);
        tool.transform.localRotation = Quaternion.Euler(tool.HoldingRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(handPosition.position, 0.1f);
    }

    public void UnequipTool()
    {
        DetachCurrentToolFromHand();
        currentTool = null;
    }
}
