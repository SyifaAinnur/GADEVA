using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private Inventory inventory;


    public void StartPauseAdv()
    {
        inventory.LoadItem();
        menuUI.SetActive(true);
        Time.timeScale = 0;
    }

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
