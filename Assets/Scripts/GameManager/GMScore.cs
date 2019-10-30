using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GMScore : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private int scoreToWin = 100;
    
    public readonly UnityEvent GameWon = new UnityEvent();

    public int Score => _score;

    public void AddScore(GameObject enemy)
    {
        _score += enemy.GetComponent<Enemy>().ScoreValue;
        if (Score >= scoreToWin) GameWon.Invoke();
    }
}
