using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWinEndless : MonoBehaviour
{
   [SerializeField] GameObject winPanel;
   [SerializeField] PauseMenu1 pauseMenu;
   [SerializeField] BOSSKATA Dialogue;
   [SerializeField] GameObject pauseButton;

   public void winCondition()
   {
       pauseMenu.isPause = true;
       winPanel.SetActive(true);
       pauseButton.SetActive(false);
       Dialogue.StartCoroutine(Dialogue.winBossChat(GameObject.FindWithTag("Player")));
   }
}
