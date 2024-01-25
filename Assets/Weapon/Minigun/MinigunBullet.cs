using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{

    void Awake()
    {
        StartCoroutine("Die");
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
