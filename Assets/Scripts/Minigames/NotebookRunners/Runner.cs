using System;
using UnityEngine;
using Input.Core;

public class Runner : MonoBehaviour
{
    [SerializeField] private float _speed = 16f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private int _id;
    private bool _isUpsideDown = false;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    public Action<int> OnDie;
    
    public void Initialize(int playerId)
    {
        _id = playerId;
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    public void OnUpdate()
    {
        
    }
    
    void Update()
    {
        if (InputSystem.CurrentInputProvider.GetKeyDown(0, _id))
        {
            gravity = -gravity;
            transform.Rotate(new Vector3(0, 0, 180f));
        }
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed, gravity) * 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke(_id);
        Debug.Log(_id);
        Destroy(gameObject);
    }
    
    public int GetPlayerId()
    {
        return _id;
    }
}
