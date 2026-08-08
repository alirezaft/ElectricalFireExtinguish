using RTLTMPro;
using UnityEngine;

public class EndUIText : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro endText;
    
    public void SetText(string text)
    {
        endText.text = text;
    }
}
