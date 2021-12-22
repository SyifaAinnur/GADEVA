using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        Time.timeScale = 0f;

    }

    // Update is called once per frame
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
