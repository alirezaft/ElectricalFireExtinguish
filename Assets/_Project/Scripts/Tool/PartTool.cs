using Tools;
using UnityEngine;

namespace Tools
{
    public class PartTool : Tool
    {
        [SerializeField] private Transform operationPoint;
        public Transform OperationPoint => operationPoint;
        
        public override void Use()
        {
            
        }

        public void MoveToPartInteractionPoint(Vector3 partPosition)
        {
            transform.MoveChildTo(operationPoint, partPosition);
        }
        
    }
}