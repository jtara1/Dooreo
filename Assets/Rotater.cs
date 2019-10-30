using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private Transform rotateAround;
    [SerializeField] private float speed = 1f;

    private float _targetRotation;
    private Vector3 _targetPoint;

    private bool _rotated = true;

    // Start is called before the first frame update
    void Start()
    {
        _targetRotation = rotateAround.rotation.y;
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Math.Abs(_targetRotation - rotateAround.rotation.y) > 0.01)
        {
            transform.RotateAround(_targetPoint, rotateAround.up, _targetRotation * Time.deltaTime * speed);
//            transform.Rotate(rotateAround.up, _targetRotation / 36 * Time.deltaTime * speed, Space.Self);
        }
        else
        {
            _rotated = true;
        }
    }

    public void Rotate()
    {
        _rotated = false;
        _targetRotation = rotateAround.rotation.y + 360f;
        _targetPoint = transform.position * -1;
    }
}
