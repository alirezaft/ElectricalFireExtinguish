using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace Interactables.Behaviours
{
    public class InteractableVFXDisabler : MonoBehaviour, IInteractableBehaviour
    {
        [SerializeField] private VisualEffect[] effects;

        public void ExecuteBehaviour()
        {
            foreach (var effect in effects)
            {
                effect.Stop();
            }

            StartCoroutine(DisableVFXObjects());
        }

        private IEnumerator DisableVFXObjects()
        {
            if (TryGetComponent<AudioSource>(out var audiosoure))
                audiosoure.enabled = false;
            yield return new WaitForSeconds(1.5f);

            foreach (var effect in effects)
            {
                effect.gameObject.SetActive(false);
            }
        }
    }
}