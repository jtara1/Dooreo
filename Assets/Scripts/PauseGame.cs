using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else if(isPaused == true)
            {
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                isPaused = false;
                Time.timeScale = 1;
            }
        }
        
    }
}
