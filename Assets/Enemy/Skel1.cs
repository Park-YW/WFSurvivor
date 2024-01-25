using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skel1 : MonoBehaviour
{
    public GameObject target;
    public Rigidbody _rigidbody;
    public NavMeshAgent _nav;
    public Animator _animator;

    void Awake()
    {
        gameObject.SetActive(true);
        _rigidbody = GetComponent<Rigidbody>();
        _nav = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        target = FindFirstObjectByType<player>().gameObject;
    }

    void Update()
    {
        if(Vector3.Distance(target.transform.position, transform.position) < 1)
        {
            _animator.SetBool("inRange", true);
        }
        else
        {
            _nav.destination = target.transform.position;
            _animator.SetBool("inRange", false);
        }
        
        
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("f");
            gameObject.SetActive(false);
        }
    }
}
