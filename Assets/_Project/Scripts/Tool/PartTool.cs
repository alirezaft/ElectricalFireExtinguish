using Tools;
using UnityEngine;

namespace Tools
{
    public class PartTool : Tool
    {
        [SerializeField] private Transform operationPoint;
        public Transform OperationPoint => operationPoint;
        
        public override void Use(Part part)
        {
            Debug.Log("Using tool");
            transform.parent = null;
            MoveToPartInteractionPoint(part.InteractionPoint.position);
            interactableAnimator.PlayAnimation();
            //TODO: Go in working rotation
            //TODO: Notify when work is done
        }

        public void MoveToPartInteractionPoint(Vector3 partPosition)
        {
            transform.MoveChildTo(operationPoint, partPosition);
        }

        public override void FinishWorking()
        {
            scenarioManager.PlayerEquipper.PutInHand(this);
            scenarioManager.PlayPartAnimation();
            
        }
    }
}