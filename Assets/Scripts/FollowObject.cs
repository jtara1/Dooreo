using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;

    private Transform _transformToFollow;

    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _transformToFollow = objectToFollow.GetComponent<Transform>();
        _offset = transform.position - _transformToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        Vector3 newPosition = new Vector3(
            _transformToFollow.position.x + _offset.x, 
            transform.position.y, 
            _transformToFollow.position.z + _offset.z
        );

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10);
    }
}
