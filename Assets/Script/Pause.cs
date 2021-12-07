using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    public void StartPause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0;
        //Debug.Log("pause");
    }
    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
