using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText($"Health: {Character.Instance.Health.ToString()}");
    }
}
