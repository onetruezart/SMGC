using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Minigames.ShipBattle
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Start()
        {
            Destroy().Forget();
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }

        private async UniTaskVoid Destroy()
        {
            await UniTask.Delay(8000);
            if (gameObject) 
                Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("World") || collision.gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}
