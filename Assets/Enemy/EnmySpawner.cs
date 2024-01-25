using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmySpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnRate = 1000f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            //var go = Instantiate(spawnPrefab);
            //go.transform.position = transform.position;
            
            yield return new WaitForSeconds(spawnRate);
            RoundSpawn();
        }
    }

    void RoundSpawn()
    {
        for (var i = 0; i<=360; i+=20)
        {
            transform.rotation = Quaternion.Euler(0, i, 0);
            var spawnedskul = Instantiate(spawnPrefab, null, true);
            spawnedskul.transform.position = transform.position;
            spawnedskul.transform.position += transform.forward*15;
        }
        
        
        
    }
}
