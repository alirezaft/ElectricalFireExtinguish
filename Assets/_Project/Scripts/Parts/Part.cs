using Parts;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

public class Part : Interactable
{
    [SerializeField] private PartType partType;
    public PartType PartType => partType; 
    
    [SerializeField] private Transform interactionPoint;
    public Transform InteractionPoint => interactionPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
