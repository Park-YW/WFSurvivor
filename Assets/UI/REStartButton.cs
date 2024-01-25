using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class ReStartButton : MonoBehaviour
{
    void Start()
    {
    }
    public void OnClick()
    {   
        EventManager.Instance.EmitEvent("gameStart", null);
        gameObject.SetActive(false);
    }

    

}
