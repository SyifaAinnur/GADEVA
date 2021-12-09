using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum GameState
{
    FreeRoam, Dialog, DialogIdle, Paused
}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;
    [SerializeField] private Pause pausebtn;
    GameState state;
    GameState stateBeforePause;




    public static GameController Instance { get; private set; }

    void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };

        DialogManagerIdle.Instance.OnShowDialogIdle += () =>
        {
            state = GameState.DialogIdle;
        };

        DialogManagerIdle.Instance.OnCloseDialogIdle += () =>
        {
            if (state == GameState.DialogIdle)
                state = GameState.FreeRoam;
        };
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            stateBeforePause = state;
            state = GameState.Paused;

        }
        else
        {
            state = stateBeforePause;
        }
    }


    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.DialogIdle)
        {
            DialogManagerIdle.Instance.HandleUpdate();
        }

    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        //cekl apakah work
        Debug.Log("game Keluar");
    }
}
