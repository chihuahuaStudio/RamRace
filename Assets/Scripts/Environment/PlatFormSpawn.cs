using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatFormSpawn : MonoBehaviour
{
    public GameObject[] platformSpawner;
    [SerializeField] private GameObject lastCreatedPlatform;
    private Vector3 _spawnPos;
    private float _platformWidth;
    private BoxCollider2D _platformBox;
    private float _platformSpace = 3f;
    private float _ySpawnPos;
    void Start()
    {
        _ySpawnPos = transform.position.y;
        _spawnPos = transform.position;
    }

     void Update()
     {
         if (lastCreatedPlatform.transform.position.x < _spawnPos.x)
         {
            PlatformSpawn();
         }
     }

     private void PlatformSpawn()
    {
        Vector3 platformPosition = new Vector3(_spawnPos.x + _platformWidth + _platformSpace, _ySpawnPos, 0f);
        int platformIndex = Random.Range(0, platformSpawner.Length);
        lastCreatedPlatform = Instantiate(platformSpawner[platformIndex], platformPosition, Quaternion.identity);
        _platformBox = lastCreatedPlatform.GetComponent<BoxCollider2D>();
        _platformWidth = _platformBox.bounds.size.x;
        


    }
 
}
