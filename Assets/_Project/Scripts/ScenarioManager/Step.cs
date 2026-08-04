using System;
using Tools;
using UnityEngine;

namespace GameManager
{
    [CreateAssetMenu(menuName = "Game/Scenario Step", fileName = "New Scenario Step")]
    public class Step : ScriptableObject
    {
        [SerializeField] private Step nextStep;
        public Step NextStep => nextStep;
        
        [SerializeField] private ToolType requiredTool;
        public ToolType RequiredTool => requiredTool;
        
        [SerializeField] private GameObject targetObject;

        [SerializeField] private string objectiveText;
        public string ObjectiveText => objectiveText;

        public event Action OnStepStart;
        public event Action OnStepComplete;
    }
}