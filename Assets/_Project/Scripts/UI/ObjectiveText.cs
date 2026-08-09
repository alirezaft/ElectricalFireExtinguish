using UnityEngine;
using GameManager;
using GameManager.Steps;
using RTLTMPro;

namespace UI
{
    public class ObjectiveText : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro objectiveText;
        [SerializeField] private ScenarioManager scenarioManager;

        private void OnEnable()
        {
            scenarioManager.OnStepChange += UpdateObjectiveText;
            scenarioManager.OnScenarioFinish += DestroyGameObject;
        }

        private void DestroyGameObject()
        {
            scenarioManager.OnStepChange -= UpdateObjectiveText;
            scenarioManager.OnScenarioFinish += DestroyGameObject;

            Destroy(gameObject);
        }

        private void OnDisable()
        {
            scenarioManager.OnStepChange -= UpdateObjectiveText;
            scenarioManager.OnScenarioFinish += DestroyGameObject;
        }

        private void UpdateObjectiveText(Step step, int stepIndex)
        {
            if (step is EndStep) return;
            
            objectiveText.text = step.ObjectiveText;
        }
    }
}