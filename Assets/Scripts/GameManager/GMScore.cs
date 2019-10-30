using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GMScore : MonoBehaviour
{
    public static GMScore Instance;
    
    private int _score = 0;
    [SerializeField] private int scoreToWin = 10000;
    
    public readonly UnityEvent GameWon = new UnityEvent();

    public int Score => _score;

    void Start()
    {
        Instance = this;
    }

    public void AddScore(GameObject enemy)
    {
        _score += enemy.GetComponent<Enemy>().ScoreValue;
        if (Score >= scoreToWin) GameWon.Invoke();
    }
}
