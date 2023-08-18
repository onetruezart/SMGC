using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _followSpeed;
        [SerializeField] private float _defaultSpeed;
        [SerializeField] private float _xOffset;
        
        private Transform _target;
    
        private void FixedUpdate()
        {
            _target = NotebookRunnersMinigame.LeadingRunner.transform;

            if (transform.position.x + _xOffset > _target.position.x)
            {
                transform.position += Vector3.right * (_defaultSpeed*Time.deltaTime);
            }
        
            else
            {
                Vector3 newPos = new Vector3(_target.position.x-_xOffset, transform.position.y, -10f);
                transform.position = Vector3.Lerp(transform.position, newPos, _followSpeed * Time.deltaTime);
                transform.position += Vector3.right * (_defaultSpeed * Time.deltaTime);
            }
        }
    }
}
