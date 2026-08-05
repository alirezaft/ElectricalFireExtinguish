using Tools;
using UnityEngine;

namespace GameManager
{
    [CreateAssetMenu(menuName = "Game/Step/Cutscene Step", fileName = "NewCutsceneStep")]
    public class CutsceneStep : Step
    {
        public override bool CanInteract(Interactable interactable, ScenarioManager manager)
        {
            return true;
        }
    }
}