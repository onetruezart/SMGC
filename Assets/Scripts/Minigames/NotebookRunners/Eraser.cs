using System;
using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class Eraser : MonoBehaviour
    {
        [SerializeField] private float _movementRangeMultiplier;
        [SerializeField] private float _speed;
        [SerializeField] private float _yOffset;

        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, (float)Math.Sin(Time.time*_speed)*_movementRangeMultiplier + _yOffset, transform.position.z);
        }

        // private void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (other.gameObject.CompareTag("World"))
        //         Destroy(other.gameObject);
        // }
    }
}
