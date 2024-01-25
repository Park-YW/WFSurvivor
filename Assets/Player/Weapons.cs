using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Player, Minigun;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate()
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }
}
