using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        //EventManager.Instance.SubscribeEvent("gameOver", OnGameOver);
    }
    void GameOver(object param)
    {
        Debug.Log("fff");
        restartButton.gameObject.SetActive(true);
    }
}
