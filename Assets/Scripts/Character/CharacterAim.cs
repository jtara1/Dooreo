using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    private static float ASPECT_RATIO_16_BY_9_BIAS = 15;
    
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
        angle = this.AddAspectRatioDistortionCorrection(angle, viewportPoint.x < 0);

        if (viewportPoint.y > 0)
        {
            angle *= -1;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    float AddAspectRatioDistortionCorrection(float degrees, bool addCorrection = false)
    {
        // equivalent angle in 1st quadrant
        float referenceAngle;
        if (degrees <= 90)
        {
            referenceAngle = degrees;
        }
        else if (degrees <= 180)
        {
            referenceAngle = degrees - 90;
        }
        else if (degrees <= 270)
        {
            referenceAngle = degrees - 180;
        }
        else
        {
            referenceAngle = degrees - 270;
        }
        
        // f(x) = 1 - (1 / 2025) * (45 - x)^2
        // roots at 0 and 90; parabola vertex at (45, 1)
        float closenessTo45Degrees = 1 - Mathf.Pow(45 - referenceAngle, 2) / 2025;
        closenessTo45Degrees = Mathf.Max(closenessTo45Degrees, 0);

        float correction = CharacterAim.ASPECT_RATIO_16_BY_9_BIAS * closenessTo45Degrees;
        return degrees + (addCorrection ? 1 : -1) * correction;
    }
    
    Vector3 GetCenter()
    {
        return Camera.main.WorldToViewportPoint(transform.position);
    }
}
