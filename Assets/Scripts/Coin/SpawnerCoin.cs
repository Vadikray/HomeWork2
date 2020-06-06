using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;
                int spawmPointNamber = Random.Range(0, _spawnPoints.Length);

                SetPrefab(prefab, _spawnPoints[spawmPointNamber].position);
            }
        }
    }

    private void SetPrefab(GameObject prefab, Vector3 spawnPoint)
    {
        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }
}
