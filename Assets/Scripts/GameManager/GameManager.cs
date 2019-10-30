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
        _gmScore.GameWon.AddListener(GameEnd);
    }

    public void AddEnemyDeathListener(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Died.AddListener(_gmScore.AddScore);
    }

    public void Ping()
    {
        Debug.Log("GM: Pong");
    }

    private void GameEnd()
    {
        Debug.Log("End Game");
        StartCoroutine("QuitGame", new object[] {5})
    }

    private IEnumerator QuitGame(object[] args)
    {
        yield return new WaitForSeconds((int)args[0]);
        Application.Quit();
    }
}
