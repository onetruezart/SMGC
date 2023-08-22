using System;
using Input.Core;
using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity;
        [SerializeField] private int _id;
        private bool _isJumpAllowed = true;
        private Rigidbody2D _rigidbody;
    
        public Action<int> OnDie;
        public Action<int> OnFinish;
    
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
            _rigidbody.velocity = new Vector2(_speed, _gravity*1.2f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _isJumpAllowed = true;
        
            if (other.gameObject.CompareTag("Death"))
            {
                Die();
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                Finish();
            }
        }

        private void Finish()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            OnFinish?.Invoke(_id);
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
}
