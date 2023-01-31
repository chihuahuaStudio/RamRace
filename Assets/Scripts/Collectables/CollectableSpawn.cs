using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] collectableArray;
    private Vector3 _spawnPos;
    private float _spawnTime;
    private float _spawnDelay;


    private void Awake()
    {
        _spawnPos = transform.position;
        _spawnTime = Random.Range(8f,10f);
        _spawnDelay = Random.Range(5f, 8f);
    }

    void Start()
    {
        
        InvokeRepeating("SpawnCollectables", _spawnTime, _spawnDelay);
    }

    private void SpawnCollectables()
    {
        int index = Random.Range(0, collectableArray.Length);
        Instantiate(collectableArray[index], SpawnPosition(), transform.rotation);
    }

    private Vector3 SpawnPosition()
    {
        float yPos = Random.Range(2.5f, 7f);
         Vector3 randomSpawnPos = new Vector3(transform.position.x, yPos, transform.position.z);
         //Debug.Log($"ypos: {yPos}");
         return randomSpawnPos;
    }
}
