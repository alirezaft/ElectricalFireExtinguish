using Tools;
using UnityEngine;

namespace Tools
{
    public abstract class LongRangeTool : Tool
    {
        [SerializeField] private Transform shootingOrigin;
        public Transform ShootingOrigin => shootingOrigin;
    }
}