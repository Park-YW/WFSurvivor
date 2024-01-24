using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.AddForce(transform.forward * 100, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
