using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject _player;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update() 
    {
        transform.position = _player.transform.position;
    }

    
}
