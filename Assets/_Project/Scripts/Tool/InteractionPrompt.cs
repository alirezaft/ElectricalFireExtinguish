using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    [SerializeField] private GameObject toolInteractionPromptUI;

    public void EnableInteractionUI()
    {
        toolInteractionPromptUI.SetActive(true);
    }

    public void DisableInteractionUI()
    {
        toolInteractionPromptUI.SetActive(false);
    }
}
