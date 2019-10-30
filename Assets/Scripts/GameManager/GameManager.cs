using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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

    private void GameEnd()
    {
        ShowVictoryText();
        StartCoroutine("QuitGame", new object[] {5});
    }

    private void ShowVictoryText()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
        
        TextMeshProUGUI textComponent = texts.SingleOrDefault(text => text.name == "WinText");
        textComponent?.SetText("Victory!");
    }

    private IEnumerator QuitGame(object[] args)
    {
        yield return new WaitForSeconds((int)args[0]);
        if (Application.isEditor) UnityEditor.EditorApplication.isPaused = true;
        Application.Quit();
    }
}
