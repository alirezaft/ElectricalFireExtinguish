using Interactables.Parts;
using UnityEngine;

namespace Interactables.Tools
{
    public class LongRangeTool : Tool
    {
        [SerializeField] private Transform shootingOrigin;
        [SerializeField] private float range;
        public float Range => range;
        
        public override void FinishWorking()
        {
            scenarioManager.ExecutePartBehaviours();
            scenarioManager.UnlockPlayerMovementAndLook();
        }

        public override void Use(Part targetPart)
        {
            Aim(targetPart.transform);
            ExecuteBehaviours();
            PlaySound();
            scenarioManager.LockPlayerMovementAndLook();
        }

        private void Aim(Transform target)
        {
            var direction = (target.position - shootingOrigin.position).normalized;
            shootingOrigin.rotation = Quaternion.LookRotation(direction);
        }
        
    }
}