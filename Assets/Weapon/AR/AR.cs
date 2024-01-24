using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    public GameObject bullet;
    public int level=1;


    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("FireRate");
    }

    // Update is called once per frame
    void Update()
    {
        //var bulletGameObject = PoolingManager.Instance.Get("bullet");
        
        //Invoke("Fire",1f);
        
    }
    void Fire()
    {
        var firedBullet = Instantiate(bullet, null, true);
        firedBullet.SetActive(true);
        firedBullet.transform.forward = transform.forward;
        firedBullet.transform.position = transform.position + new Vector3(0, 0.7f, 0);
        
        var bullet_rigidBody = firedBullet.GetComponent<Rigidbody>();
        bullet_rigidBody.AddForce(transform.forward * 1f, ForceMode.Impulse);
    }

    IEnumerator FireRate()
    {
        Fire();
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("FireRate");
    }
}
