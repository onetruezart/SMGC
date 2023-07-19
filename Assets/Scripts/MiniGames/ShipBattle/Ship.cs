using System;
using Input.Core;
using UnityEngine;

namespace MiniGames.ShipBattle
{
   public class Ship : MonoBehaviour
   {
      [SerializeField] private float _speed;
      [SerializeField] private float _angularSpeed;
      [SerializeField] private InputSystem _inputSystem;

      private void Start()
      {
         _inputSystem.Initialize(1);
      }

      private void Update()
      {
         if (InputSystem.CurrentInputProvider.GetKeyDown(0, 0))
         {
            _angularSpeed = -_angularSpeed;
         }
      
         if (InputSystem.CurrentInputProvider.GetKey(0, 0))
         {
            transform.Translate(-Vector3.right * (_speed * Time.deltaTime));
         }
         else
         {
            transform.rotation *= Quaternion.AngleAxis(_angularSpeed * Time.deltaTime, Vector3.up);
         }
      }
   }
}
