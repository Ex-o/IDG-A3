using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float _speed = 10f;
    public float gravity = -10f;
    private float _turnLerp = 10f;
    private float _speedLerp = 50f;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        dir = Camera.main.transform.rotation * dir;
        dir.y = 0;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),
                _turnLerp * Time.deltaTime);
        }

        dir *= _speed;
        dir.y += gravity * _speedLerp * Time.deltaTime;
        controller.Move(dir * Time.deltaTime);
    }
 
}