using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject aboutButton;
    public GameObject quitButton;
    public GameObject aboutText;
    public GameObject exitAboutButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutSection()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        aboutButton.SetActive(false);
        aboutText.SetActive(true);
        exitAboutButton.SetActive(true);
    }

    public void ReturnFromAbout()
    {
        playButton.SetActive(true);
        quitButton.SetActive(true);
        aboutButton.SetActive(true);
        aboutText.SetActive(false);
        exitAboutButton.SetActive(false);
    }

}

