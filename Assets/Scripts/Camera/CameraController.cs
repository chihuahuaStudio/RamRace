using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 _cameraVelocity;
    //[SerializeField] private float _smoothTime = 1f;
    [SerializeField] private float yLowerLimit = -3f;
    [SerializeField] private bool isCameraLooking;
    
    // Update is called once per frame
    void LateUpdate()
    {
       
        if (playerTransform.position.y > yLowerLimit)
        {

            transform.position = new Vector3(transform.position.x,
                playerTransform.position.y, transform.position.z);
            //Vector3 targetPosition = new Vector3(transform.position.x,
            //    playerTransform.position.y, transform.position.z);
            //transform.position = Vector3.SmoothDamp(transform.position,
            //    targetPosition, ref _cameraVelocity, _smoothTime);
            if (isCameraLooking)
                transform.LookAt(playerTransform);
        }
       
    }
}
