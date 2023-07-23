using System;
using Input.Core;
using UnityEngine;
using Utility;

namespace Minigames.ShipBattle
{
   //TODO: IMinigameEntity
   public class Ship : MonoBehaviour
   {
      [SerializeField] private float _speed;
      [SerializeField] private float _angularSpeed;
      [SerializeField] private int _id;
      [SerializeField] private GameObject _canonL, _canonR;
      [SerializeField] private GameObject _bullet;

      private int _shootCounter = 0;

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
         LaunchBullet(_shootCounter % 2 == 0 ? _canonL : _canonR);

         _shootCounter += 1;
      }

      private void LaunchBullet(GameObject canon)
      {
         var bullet = Instantiate(_bullet, canon.transform.position, Quaternion.identity);
         bullet.transform.eulerAngles = canon.transform.eulerAngles.WithX(0);
      }

      private void Die()
      {
         OnDie?.Invoke(_id);
         //TODO: Animation
         Destroy(gameObject);
      }
      
      private void OnCollisionEnter(Collision collision)
      {
         if (collision.gameObject.CompareTag("Death"))
            Die();
      }

      public int GetPlayerId()
      {
         return _id;
      }
   }
}
