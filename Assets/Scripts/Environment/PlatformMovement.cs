
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xLimit;
    
    
    void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        if (transform.position.x < xLimit)
            Destroy(gameObject);
    }
}
