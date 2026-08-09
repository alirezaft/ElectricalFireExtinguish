using RTLTMPro;
using UnityEngine;

namespace UI
{
    public class EndUIText : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro endText;

        public void SetText(string text)
        {
            endText.text = text;
        }
    }
}