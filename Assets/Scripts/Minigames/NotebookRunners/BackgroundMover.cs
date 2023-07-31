using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private float offset;
    private Material _material;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime / 10f;
        _material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
