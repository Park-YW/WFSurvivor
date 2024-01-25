using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {   
        Debug.Log("ff");
        EventManager.Instance.EmitEvent("gameStart", null);
    }
    public void GameStart()
    {
        
    }

}
