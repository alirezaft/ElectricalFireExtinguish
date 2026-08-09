using UnityEngine;

namespace VisualEffects
{
    public class Highlighter : MonoBehaviour
    {
        [Header("Emission")] [SerializeField] private Color emissionColor = Color.white;
        [SerializeField, Min(0f)] private float minIntensity = 0f;
        [SerializeField, Min(0f)] private float maxIntensity = 5f;

        [Header("Animation")] [SerializeField, Min(0.01f)]
        private float cycleDuration = 2f;

        [SerializeField] private Renderer[] renderers;
        private Material[] materialInstances;

        private static readonly int EmissionColorID = Shader.PropertyToID("_EmissionColor");

        private void Awake()
        {
            materialInstances = new Material[renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
            {
                materialInstances[i] = renderers[i].material;
            }
        }

        private void OnEnable()
        {
            foreach (var material in materialInstances)
            {
                material.EnableKeyword("_EMISSION");
            }
        }

        private void Update()
        {
            var intensity = CalculateIntensity();
            
            SetMaterialColors(intensity);
        }

        private float CalculateIntensity()
        {
            var t = Mathf.PingPong(Time.time / cycleDuration, 1f);

            t = Mathf.SmoothStep(0f, 1f, t);

            var intensity = Mathf.Lerp(minIntensity, maxIntensity, t);

            return intensity;
        }

        private void SetMaterialColors(float intensity)
        {
            foreach (var material in materialInstances)
            {
                material.SetColor(
                    EmissionColorID,
                    emissionColor * intensity
                );
            }
        }

        private void OnDisable()
        {
            foreach (var material in materialInstances)
            {
                material.SetColor(
                    EmissionColorID,
                    emissionColor * 0
                );
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}