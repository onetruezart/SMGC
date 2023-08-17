using System;
using UnityEngine;
using Input.Core;

public class Runner : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private int _id;
    private bool _isJumpAllowed = false;
    private Rigidbody2D _rigidbody;
    
    public Action<int> OnDie;
    
    public void Initialize(int playerId)
    {
        _id = playerId;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnUpdate()
    {
        
    }
    
    public void Update()
    {
        if (InputSystem.CurrentInputProvider.GetKeyDown(0, _id) && _isJumpAllowed)
        {
            _gravity = -_gravity;
            _isJumpAllowed = false;
            
            transform.Rotate(new Vector3(0, 0, 180f));
        }
    }

    public void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed, _gravity*1.1f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Die();
        }
        
        _isJumpAllowed = true;
    }

    private void Die()
    {
        OnDie?.Invoke(_id);
        Destroy(gameObject);
    }
    
    public int GetPlayerId()
    {
        return _id;
    }
}
