using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScore : MonoBehaviour
{
    private int _score = 0;

    public int Score => _score;

    public void AddScore(GameObject enemy)
    {
        _score += enemy.GetComponent<Enemy>().ScoreValue;
    }
}
