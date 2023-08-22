using System;
using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class EraserSaw : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, _rotationSpeed);
        }
    }
}
