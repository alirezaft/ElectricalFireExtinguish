using GameManager;
using Tools;
using UnityEngine;

[CreateAssetMenu(fileName = "EndStep", menuName = "Game/Step/End Step")]
public class EndStep : Step
{
    public override bool CanInteract(Interactable interactable, ScenarioManager manager)
    {
        return false;
    }
}
