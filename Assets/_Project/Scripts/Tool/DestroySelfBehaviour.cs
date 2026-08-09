using UnityEngine;

namespace Interactables.Behaviours
{
    public class DestroySelfBehaviour : MonoBehaviour, IInteractableBehaviour
    {
        public void ExecuteBehaviour()
        {
            Destroy(gameObject);
        }
    }
}