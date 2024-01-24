using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform _transform;
    public float moveSpeed = 2f;

    public Dictionary<string, int> status = new Dictionary<string, int>()
    {
        {"HP", 10},
        {"Level", 1}

    };
    void Awake()
    {
        _transform = GetComponent<Transform>();
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
    }
}
