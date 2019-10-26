using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 offset = new Vector3(0.5f, 0.5f);
        Vector3 viewportPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition) - offset;
        
        float angle = Vector3.SignedAngle(Vector3.right, viewportPoint, Vector3.up);

        if (viewportPoint.y > 0)
        {
            angle *= -1;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    /// <summary>
    /// TODO: fix
    /// Get the character position in viewport point (from perspective of camera)
    /// </summary>
    /// <returns></returns>
    Vector3 GetCenter()
    {
        return Camera.main.WorldToViewportPoint(transform.position);
    }
}
