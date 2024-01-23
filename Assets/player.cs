using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform _transform;
    // Start is called before the first frame update
    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var _horizontal = Input.GetAxis("Horizontal");
        var _vertical = Input.GetAxis("Vertical");
        var moveInput = new Vector3(_horizontal, 0, _vertical);
        transform.position += moveInput*Time.deltaTime;
    }
}
