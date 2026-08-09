using Interactables;
using UnityEngine;
using UnityEngine.Playables;

namespace GameManager.Steps
{
    [CreateAssetMenu(menuName = "Game/Step/Cutscene Step", fileName = "NewCutsceneStep")]
    public class CutsceneStep : Step
    {
        [SerializeField] private PlayableAsset cutscene;
        public PlayableAsset Cutscene => cutscene;
        
        
        public override bool CanInteract(Interactable interactable, ScenarioManager manager)
        {
            return true;
        }
    }
}