using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigun : MonoBehaviour

{

    public GameObject bullet;
    public int level=1;
    private float FireAngle = 0;


    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("FireRate");
    }

    void Enable()
    {
        //EventManager.Instance.SubscribeEvent("levelUp", levelUpMG);
    }
    void levelUpMG(object param)
    {
        level +=1;
    }
    void Fire()
    {
        var firedBullet = Instantiate(bullet, null, true);
        firedBullet.SetActive(true);
        firedBullet.transform.forward = transform.forward;
        firedBullet.transform.position = transform.position;
        
        var bullet_rigidBody = firedBullet.GetComponent<Rigidbody>();
        bullet_rigidBody.AddForce(transform.forward * 1f, ForceMode.Impulse);
        FireAngle += 10;
        transform.rotation = Quaternion.Euler(0, FireAngle, 0);
    }

    IEnumerator FireRate()
    {
        Fire();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("FireRate");
    }
}
