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
            //TODO: Go in working rotation
            //TODO: Run animation
            //TODO: Notify when work is done
        }

        public void MoveToPartInteractionPoint(Vector3 partPosition)
        {
            transform.MoveChildTo(operationPoint, partPosition);
        }
        
    }
}