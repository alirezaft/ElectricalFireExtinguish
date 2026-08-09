using UnityEngine;

namespace UI
{
    public class InteractionPromptDirection : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}