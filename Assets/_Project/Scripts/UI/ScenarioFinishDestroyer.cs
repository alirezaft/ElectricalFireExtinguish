using System;
using GameManager;
using UnityEngine;

public class ScenarioFinishDestroyer : MonoBehaviour
{
    [SerializeField] private ScenarioManager manager;

    private void OnEnable()
    {
        manager.OnScenarioFinish += DestroyGameObject;
    }

    private void OnDisable()
    {
        manager.OnScenarioFinish -= DestroyGameObject;
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
