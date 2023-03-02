using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    bool thisGameisPause = false;
    public GameObject pauseUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (thisGameisPause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;

        GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = true;
        GameObject.FindWithTag("Gun").GetComponent<Gun>().enabled = true;

        thisGameisPause = false;
    }
    void pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        
        GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = false;
        GameObject.FindWithTag("Gun").GetComponent<Gun>().enabled = false;

        thisGameisPause = true;
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    /*public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        transition.SetBool("ON", true);

    }*/
}
