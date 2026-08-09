using UnityEngine;
using UnityEngine.Playables;

namespace GameManager
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private ScenarioManager scenarioManager;
        [SerializeField] private PlayableDirector director;
        [SerializeField] private GameObject ui;
        [SerializeField] private GameObject player;

        public void PlayCutscene(PlayableAsset asset)
        {
            ui.SetActive(false);
            player.SetActive(false);
            director.Play(asset);
        }

        public void OnCutsceneFinished()
        {
            ui.SetActive(true);
            player.SetActive(true);
            scenarioManager.GoToNextStep();
        }
    }
}