using System.Collections;
using System.Collections.Generic;
using Npc_State;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject _startPoint;
    public Minigun minigun;
    public float moveSpeed = 2f;

    public int 
    _HP = 20,
    _Level = 1,
    _Exp = 0,
    _score = 0; 
    public bool _takingDamage = false;
    public GameObject HP_Bar, ScorePanel;
    public TextMeshProUGUI Score2;
    private Slider HP_Slider;

    void Awake()
    {
        
        HP_Slider = HP_Bar.GetComponent<Slider>();
        
    }

    void OnEnable()
    {
        EventManager.Instance.SubscribeEvent("gameStart", OnGameStart);
        EventManager.Instance.SubscribeEvent("attack", OnAttack);
        EventManager.Instance.SubscribeEvent("GetExp", GetExp);
        EventManager.Instance.SubscribeEvent("gameOver", Dead);
    }
    void Dead(object param)
    {
        HP_Slider.value = 1;
        HP_Bar.SetActive(false);
        ScorePanel.SetActive(false);
    }
    void OnGameStart(object param)
    {
        HP_Slider.value = _HP/20f;
        HP_Bar.SetActive(true);
        ScorePanel.SetActive(true);
        transform.position = new Vector3(0,0,0);
        _HP = 20;
        _Exp = 0;
        _score = 0;
    }
    void OnAttack(object param)
    {
        if(_takingDamage == false)
        {
            HP_Slider.value = _HP/20f;
            _HP -= 1;
            StartCoroutine("Timer");
        }
        

    }
    IEnumerator Timer()
    {
        _takingDamage = true;
        yield return new WaitForSeconds(0.4f);
        _takingDamage =false;
    }
    
    void GetExp(object param)
    {
        _score+=1;
        _Exp+=1;
        Score2.text = "Score : " + _score.ToString();
        if (_Exp >= _Level*2)
        {
            
            FindFirstObjectByType<AR>().levelUpAR(null);
            _Level+=1;
            _Exp = 0;
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
