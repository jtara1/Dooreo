using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        SetPositionToMouses();
    }

    void SetPositionToMouses()
    {
        transform.position = Input.mousePosition;
    }
}
