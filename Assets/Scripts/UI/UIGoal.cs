using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGoal : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        string score = FindObjectOfType<GMScore>().ScoreToWin.ToString();
        GetComponent<TextMeshProUGUI>().SetText($"Goal: {score}");
    }
}
