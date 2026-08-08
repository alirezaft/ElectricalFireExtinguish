using UnityEngine;

namespace Tools{
public class AnimationScaleCorrector : MonoBehaviour
{
    public void CorrectScale()
    {
        transform.localScale = Vector3.one;
    }
}
}