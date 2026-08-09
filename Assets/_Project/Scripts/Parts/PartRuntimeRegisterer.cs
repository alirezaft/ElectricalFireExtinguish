using GameManager;
using UnityEngine;

namespace Interactables.Parts
{
    public class PartRuntimeRegisterer : MonoBehaviour
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
}