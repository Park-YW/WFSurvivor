using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmySpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnRate = 2f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var go = Instantiate(spawnPrefab);
            go.transform.position = transform.position;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
