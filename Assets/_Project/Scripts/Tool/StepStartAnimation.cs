using System;
using GameManager;
using UnityEngine;

namespace Tools
{
    public class StepStartAnimation : MonoBehaviour
    {
        [SerializeField] private ScenarioManager manager;
        [SerializeField] private Animator animator;
        [SerializeField] private int targetStepIndex;
        [SerializeField] private string animationTriggerName;

        private void Awake()
        {
            manager.OnStepChange += PlayAnimation;
        }

        private void PlayAnimation(Step step, int stepIndex)
        {
            if (stepIndex == targetStepIndex)
            {
                animator.SetTrigger(Animator.StringToHash(animationTriggerName));
            }
        }
    }
}