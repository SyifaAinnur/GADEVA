using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{

    [SerializeField] TurnOffEssentialObject turnOff;
    GameObject pauseMenu;

    [HideInInspector] public bool isPause = false;

    private void Start()
    {
        Time.timeScale = 1f;
        pauseMenu = gameObject;
        pauseMenu.SetActive(false);
      
    }

    public void Pause()
    {
        if(!pauseMenu) {
        return;
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
     

      
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Restart()
    {
        turnOff.player.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Wave 1");
        isPause = false;
    }

    public void Quit(string sceneName)
    {
        turnOff.player.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        isPause = false;
    }
}
