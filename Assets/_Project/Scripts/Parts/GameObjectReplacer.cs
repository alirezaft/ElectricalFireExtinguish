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
        var newInstance = Instantiate(newGameObject, spawnPoint.position, transform.rotation);
        newInstance.transform.parent = transform.parent;
        
        Destroy(gameObject);
    }
}
