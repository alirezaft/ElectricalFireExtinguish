using System;
using GameManager;
using Tools;
using UnityEngine;

public class PartRuntimeRegosterer : MonoBehaviour
{
    private ScenarioManager manager;
    [SerializeField] private Part part;
    
    private void Awake()
    {
        manager = ScenarioManager.instance;
        
        manager.RegisterInteractable(part);
        part.scenarioManager = manager;

    }
}
