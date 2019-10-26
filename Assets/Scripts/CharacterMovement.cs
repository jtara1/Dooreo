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

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
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

    void Rotation()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector3.Angle(target, transform.position);
        transform.eulerAngles = new Vector3(0,angle,0);
        Debug.Log(target);
    }
}
