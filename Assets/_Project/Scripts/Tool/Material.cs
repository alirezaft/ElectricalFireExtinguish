using Interactables.Parts;

namespace Interactables.Tools
{
    public class Material : Tool
    {
        public override void FinishWorking()
        {
            throw new System.NotImplementedException();
        }

        public override void Use(Part targetPart)
        {
            scenarioManager.PlayerEquipper.UnequipTool();
            scenarioManager.ExecutePartBehaviours();
            PlaySound();
            Destroy(gameObject);
        }
    }
}