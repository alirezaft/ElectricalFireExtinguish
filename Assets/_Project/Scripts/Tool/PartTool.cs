using UnityEngine;
using Interactables.Parts;
using Utils;

namespace Interactables.Tools
{
    public class PartTool : Tool
    {
        [SerializeField] private Transform operationPoint;
        public Transform OperationPoint => operationPoint;

        [SerializeField] private Vector3 workingRotation;
        public Vector3 WorkingRotation => workingRotation;

        public override void Use(Part part)
        {
            transform.parent = null;
            GoIntoWorkingTransform(part.InteractionPoint.position);
            ExecuteBehaviours();
            scenarioManager.LockPlayerMovementAndLook();
            PlaySound();
            //TODO: Notify when work is done
        }

        private void GoIntoWorkingTransform(Vector3 partPosition)
        {
            transform.rotation = Quaternion.Euler(workingRotation);
            transform.MoveChildTo(operationPoint, partPosition);
        }

        public override void FinishWorking()
        {
            scenarioManager.PlayerEquipper.PutInHand(this);
            scenarioManager.ExecutePartBehaviours();
            scenarioManager.UnlockPlayerMovementAndLook();
        }
    }
}