using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private bool wasdOnly = false;
    [SerializeField]
    public float Speed = 15f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal, vertical;
        if (!wasdOnly)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        else
        {
            horizontal = Input.GetKey(KeyCode.D) ? 1 : 0 - (Input.GetKey(KeyCode.A) ? 1 : 0);
            vertical = Input.GetKey(KeyCode.W) ? 1 : 0 - (Input.GetKey(KeyCode.S) ? 1 : 0);
        }
        
        _controller.SimpleMove(Speed * new Vector3(horizontal, 0, vertical));
    }
}
