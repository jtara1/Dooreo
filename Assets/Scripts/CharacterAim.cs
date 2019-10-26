using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 viewportPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector3(0.5f, 0.5f);
        float angle = Vector3.SignedAngle(Vector3.right, viewportPoint, Vector3.up);

        if (viewportPoint.y > 0)
        {
            angle *= -1;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
