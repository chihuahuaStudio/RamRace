using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnvironmentSpawn : MonoBehaviour
{
    #region Field Declarations

    public GameObject[] environmentGameObjects;
    private Vector3 _spawnPosition;
    private float _spawnTime;
    private float _spawnStartTime;

    #endregion

    #region Methods

    void Start()
    {
        _spawnTime = Random.Range(1f, 10f);
        _spawnStartTime = Random.Range(0f, 4f);
        _spawnPosition = transform.position;
        InvokeRepeating("EnvironmentSpawner", _spawnStartTime, _spawnTime);
       //StartCoroutine("SpawnCoroutine");

    }
    private void EnvironmentSpawner()
    {
        int spawnerIndex = Random.Range(0, environmentGameObjects.Length);
        Instantiate(environmentGameObjects[spawnerIndex], _spawnPosition, transform.rotation);
    }

    #endregion

    private IEnumerator SpawnCoroutine()
    {
        int _spawnDelay = Random.Range(0, 8);
        yield return new WaitForSeconds(_spawnDelay);
        EnvironmentSpawner();
    }
   
   
}
