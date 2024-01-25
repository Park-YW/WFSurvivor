using System.Collections;
using System.Collections.Generic;
using Npc_State;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {   
            Debug.Log("coin");
            EventManager.Instance.EmitEvent("GetExp", null);
            Destroy(gameObject);
        }
    }
}
