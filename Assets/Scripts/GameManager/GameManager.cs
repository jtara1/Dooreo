using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private GMScore _gmScore;

    void Awake()
    {
        Instance = this;
        _gmScore = GetComponent<GMScore>();
    }

    public void AddEnemyDeathListener(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Died.AddListener(_gmScore.AddScore);
    }

    public void Ping()
    {
        Debug.Log("GM: Pong");
    }
}
