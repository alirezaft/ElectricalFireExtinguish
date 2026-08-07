using UnityEngine;

public class InteractableParticle : MonoBehaviour, IInteractableBehaiour
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
