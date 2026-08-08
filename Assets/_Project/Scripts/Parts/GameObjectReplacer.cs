using System;
using GameManager;
using UnityEngine;
using UnityEngine.Serialization;

public class GameObjectReplacer : MonoBehaviour
{
    [FormerlySerializedAs("newWire")] [SerializeField] private GameObject newGameObject;
    [FormerlySerializedAs("newWirePoint")] [SerializeField] private Transform spawnPoint;
    
    public void Replace()
    {
        var newPosition = newGameObject.transform.parent is null
            ? spawnPoint.position
            : spawnPoint.localPosition;
        
        var newInstance = Instantiate(newGameObject, newPosition, transform.rotation);
        newInstance.transform.parent = transform.parent;
        newInstance.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 7);
        
        // wireInteractable.FinishWorking();
        
        Destroy(gameObject);
    }
}
