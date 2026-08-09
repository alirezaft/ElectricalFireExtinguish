using System;
using System.Collections.Generic;
using GameManager;
using UnityEngine;

public class DestroyComponentsOnScenarioFinish : MonoBehaviour
{
    [SerializeField] private ScenarioManager manager;
    private List<MonoBehaviour> removingMonoBehaviours;

    private void Awake()
    {
        removingMonoBehaviours = new List<MonoBehaviour>();
    }

    private void OnEnable()
    {
        manager.OnScenarioFinish += DestroyMonoBehaviours;
    }

    private void DestroyMonoBehaviours()
    {
        for (int i = 0; i < removingMonoBehaviours.Count; i++)
        {
            Destroy(removingMonoBehaviours[i]);
        }
    }

    public void AddToList(MonoBehaviour behaviour)
    {
        removingMonoBehaviours.Add(behaviour);
    }

    public void RemoveFromList(MonoBehaviour behaviour)
    {
        removingMonoBehaviours.Remove(behaviour);
    }
}
