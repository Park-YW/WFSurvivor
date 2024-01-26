using System.Collections;
using System.Collections.Generic;
using Npc_State;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skel1 : MonoBehaviour
{
    public GameObject coin;
    private GameObject target;
    private Rigidbody _rigidbody;
    private NavMeshAgent _nav;
    private Animator _animator;
    public int HP = 2;
    public bool isAttack = false;

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
        if(Vector3.Distance(target.transform.position, transform.position) < 0.5)
        {
            _animator.SetBool("inRange", true);
            EventManager.Instance.EmitEvent("attack", null);
        }
        else
        {
            _nav.destination = target.transform.position;
            _animator.SetBool("inRange", false);
        }
        if(HP <= 0)
        {
            gameObject.SetActive(false);
            var tossedcoin = Instantiate(coin, null, transform);
            tossedcoin.transform.position = transform.position;
        }
        if(Vector3.Distance(target.transform.position, transform.position)>20)
        {
            Destroy(gameObject);
        }
        
        
    }
    void OnEnable()
    {
        EventManager.Instance.SubscribeEvent("gameOver", ClearSkel);
    }
    void ClearSkel(object param)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            HP-=1;
        }
    }
}
