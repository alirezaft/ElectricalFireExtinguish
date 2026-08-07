using UnityEngine;

public class InteractableParticle : MonoBehaviour, IInteractableBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void ExecuteBehaviour()
    {
        particles.Play();
    }

    public void FinishBehaviour()
    {
        particles.Stop();
    }
}
