using UnityEngine;
using UnityEngine.Serialization;

namespace Minigames.NotebookRunners
{
    public class BackgroundMover : MonoBehaviour
    { 
        [SerializeField] private float _scrollSpeed;
        private float _offset;
        private Material _material;
        private void Start()
        {
            _material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            _offset += _scrollSpeed * Time.deltaTime / 10f;
            _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
    }
}
