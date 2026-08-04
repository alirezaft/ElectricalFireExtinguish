using UnityEngine;

namespace Tools
{
    public abstract class Tool : MonoBehaviour
    {
        [SerializeField] private ToolType toolType;
        public ToolType ToolType => toolType;

        [SerializeField] private GameObject interactionPromptUI;
        
        [SerializeField] protected Transform holdingPoint;
        public Transform HoldingPoint => holdingPoint;
        
        [SerializeField] protected Vector3 holdingRotation;
        public Vector3 HoldingRotation => holdingRotation;

        [SerializeField] private InteractionPrompt interactionPrompt;
        
        public abstract void Use();

        public virtual void StopUse()
        {
            
        }
        
        public void BringToHand(Vector3 handPosition)
        {
            transform.MoveChildTo(holdingPoint, handPosition);
        }

        public void EnableInteraction()
        {
            interactionPrompt.EnableInteractionUI();
        }
    }
}