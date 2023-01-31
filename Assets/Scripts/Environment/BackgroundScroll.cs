using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField] private float speed;
    [SerializeField] private float offset;
   
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        offset += Time.deltaTime * speed;
        _renderer.material.mainTextureOffset = new Vector2(offset, 0f);
    }
}
