using System.Collections;
using System.Collections.Generic;
using Npc_State;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject _startPoint;
    public Minigun minigun;
    public float moveSpeed = 2f;

    public int 
    _HP = 20,
    _Level = 1,
    _Exp = 0; 
    public float delayTimer = 0;
    void Awake()
    {
    }

    void OnEnable()
    {
        EventManager.Instance.SubscribeEvent("gameStart", OnGameStart);
        EventManager.Instance.SubscribeEvent("attack", OnAttack);
        EventManager.Instance.SubscribeEvent("GetExp", GetExp);
        
    }
    void OnGameStart(object param)
    {
        transform.position = new Vector3(0,0,0);
        _HP = 20;
    }
    void OnAttack(object param)
    {

        _HP -= 1;
    }
    IEnumerator Timer()
    {
        yield return null;
    }
    
    void GetExp(object param)
    {
        _Exp+=1;
        if (_Exp >= _Level*3)
        {

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        var _horizontal = Input.GetAxis("Horizontal");
        var _vertical = Input.GetAxis("Vertical");
        var _velocity = new Vector3(_horizontal, 0, _vertical);
        transform.position += _velocity*Time.deltaTime*moveSpeed;
        if (_velocity.magnitude > 0.1f)
        {
            // lerp to velocity
            transform.rotation = Quaternion.LookRotation(_velocity);
        }
        if (_HP <= 0)
        {
            EventManager.Instance.EmitEvent("gameOver", null);
        }
    }
}
