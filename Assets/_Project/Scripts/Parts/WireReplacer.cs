using UnityEngine;

public class WireReplacer : MonoBehaviour
{
    [SerializeField] private GameObject newWire;
    [SerializeField] private Transform newWirePoint;

    private void ReplaceWire()
    {
        var wire = Instantiate(newWire, newWirePoint.position, transform.rotation);
        wire.transform.parent = transform.parent;
        wire.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 7);
        
        // wireInteractable.FinishWorking();
        
        Destroy(gameObject);
    } 
}
