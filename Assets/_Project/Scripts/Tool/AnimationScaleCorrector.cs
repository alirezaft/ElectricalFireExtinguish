using UnityEngine;

namespace Tools{
public class AnimationScaleCorrector : MonoBehaviour
{
    public void CorrectScale()
    {
        Debug.Log($"Correcting scale {gameObject.name}");
        transform.localScale = Vector3.one;
    }
}
}