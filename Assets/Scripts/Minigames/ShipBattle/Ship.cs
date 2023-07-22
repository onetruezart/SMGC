using System;
using Input.Core;
using UnityEngine;

namespace Minigames.ShipBattle
{
   //TODO: IMinigameEntity
   public class Ship : MonoBehaviour
   {
      [SerializeField] private float _speed;
      [SerializeField] private float _angularSpeed;
      [SerializeField] private int _id;

      public Action<int> OnDie;

      public void Initialize(int playerId)
      {
         _id = playerId;
      }

      public void OnUpdate()
      {
         
      }

      public void Update()
      {
         if (InputSystem.CurrentInputProvider.GetKeyDown(0, _id))
         {
            Shoot();
            //Die();
            _angularSpeed = -_angularSpeed;
         }
      
         if (InputSystem.CurrentInputProvider.GetKey(0, _id))
         {
            transform.Translate(-Vector3.right * (_speed * Time.deltaTime));
         }
         else
         {
            transform.rotation *= Quaternion.AngleAxis(_angularSpeed * Time.deltaTime, Vector3.up);
         }
      }

      private void Shoot()
      {
         
      }

      private void Die()
      {
         OnDie?.Invoke(_id);
         //TODO: Animation
         Destroy(gameObject);
      }
   }
}
