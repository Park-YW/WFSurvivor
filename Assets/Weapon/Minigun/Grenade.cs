using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject grenade;
    public int level=1;
    private float FireAngle = 0;

    void Awake()
    {
        StartCoroutine("GrenadeRate");
    }

    void Update()
    {

        
    }
    void Fire()
    {
        var firedBullet = Instantiate(grenade, null, true);
        firedBullet.SetActive(true);
        firedBullet.transform.forward = transform.forward;
        firedBullet.transform.position = transform.position;
        
        var bullet_rigidBody = firedBullet.GetComponent<Rigidbody>();
        bullet_rigidBody.AddForce(transform.forward * 1f, ForceMode.Impulse);
        FireAngle += 10;
        transform.rotation = Quaternion.Euler(0, FireAngle, 0);
    }

    IEnumerator GrenadeRate()
    {
        Fire();
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("FireRate");
    }
}
