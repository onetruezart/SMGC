using Minigames.NotebookRunners;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 2f;
    [SerializeField] private float _defaultSpeed = 3f;
    [SerializeField] private float _xOffset = -5f;
        
    private Transform _target;
    
    void FixedUpdate()
    {
        _target = NotebookRunnersMinigame._leadingRunner.transform;

        if (transform.position.x+_xOffset > _target.position.x)
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
