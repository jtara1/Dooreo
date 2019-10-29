using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private GMScore _gmScore;
    private TextMeshProUGUI _textMeshProUgui;
    
    void Start()
    {
        _gmScore = FindObjectOfType<GMScore>();
        _textMeshProUgui = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshProUgui.text = $"Score: {_gmScore.Score.ToString()}";
    }
}
