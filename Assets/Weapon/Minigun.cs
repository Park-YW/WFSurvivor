using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigun : MonoBehaviour

{
    private Transform _transform;
    public GameObject bullet;
    public int level=1;

    // Start is called before the first frame update
    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //var bulletGameObject = PoolingManager.Instance.Get("bullet");
        
        //Invoke("Fire",1f);
        StartCoroutine("FireRate");
    }
    void Fire()
    {
        bullet.SetActive(true);
        //bullet.transform.position = transform.position + transform.forward / 2f;
        bullet.transform.rotation = transform.rotation;
        var firedBullet = Instantiate(bullet, transform, true);

        var bullet_rigidBody = firedBullet.GetComponent<Rigidbody>();
        //var forwardDirection = transform.forward;

        bullet_rigidBody.AddForce(transform.forward * 5f, ForceMode.Impulse);
    }

    IEnumerator FireRate()
    {
        Fire();
        yield return new WaitForSeconds(5f);
    }
}
