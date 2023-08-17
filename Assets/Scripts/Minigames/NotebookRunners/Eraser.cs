using System;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    [SerializeField] private float _movementRangeMultiplier = 5f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _yOffset = 3f;

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
