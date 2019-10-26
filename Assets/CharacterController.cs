using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private UnityEngine.CharacterController controller;
    
    [SerializeField]
    public float Speed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<UnityEngine.CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        controller.SimpleMove(Speed * new Vector3(horizontal, 0, vertical));
    }
}
