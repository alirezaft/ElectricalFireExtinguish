using System;
using UnityEngine;

namespace UI
{
    public class InteractionPromptDirection : MonoBehaviour
    {
        [SerializeField] private float distanceFromObject;
        

        private void OnEnable()
        {
            transform.position = transform.parent.position + (Vector3.up * distanceFromObject);
        }

        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}