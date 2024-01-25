using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {   
        EventManager.Instance.EmitEvent("gameStart", null);
        Debug.Log("ffff");
        gameObject.SetActive(false);
    }
    public void GameStart()
    {

    }

}
