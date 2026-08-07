using Tools;
using UnityEngine;

namespace Tools
{
    public class LongRangeTool : Tool
    {
        public override void FinishWorking()
        {
            scenarioManager.FinalizeStep();
        }

        public override void Use(Part targetPart)
        {
            ExecuteBehaviours();
        }
    }
}