using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Loby,
        Play,
        GameOver
    }
    public GameState state = GameState.Loby;
    void Start()
    {
        
    }
    void OnEnable()
    {
        EventManager.Instance.SubscribeEvent("gameStart", OnGameStart);
        //EventManager.Instance.SubscribeEvent("gameOver", OnGameOver);
    }
    void OnGameStart(object param)
    {
        state = GameState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != GameState.Play)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
