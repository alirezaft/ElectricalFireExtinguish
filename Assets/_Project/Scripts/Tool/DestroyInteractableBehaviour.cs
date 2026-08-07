using UnityEngine;

public class DestroyInteractableBehaviour : MonoBehaviour, IInteractableBehaviour
{
    public void ExecuteBehaviour()
    {
        Destroy(gameObject);
    }
}
