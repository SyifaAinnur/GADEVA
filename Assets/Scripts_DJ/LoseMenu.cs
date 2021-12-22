using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] GameObject losePanel;

    //public static bool isPause = false;

    public void Restart()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //losePanel.gameObject.SetActive(false);
        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("DoodleJump");
        //isPause = false;
    }

    public void Quit(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        //isPause = false;
    }
}
