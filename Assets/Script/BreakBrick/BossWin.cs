using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossWin : MonoBehaviour
{
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;
    private int spacecount = 0;

    private bool process = false;
    [SerializeField] private GameObject pauseObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }

    public IEnumerator winBossChat(GameObject player)
    {
        pauseObj.SetActive(false);
        process = true;
        nama.text = "Boss";
        chatend.transform.parent.parent.gameObject.SetActive(true);
        chatend.text = "Kamu telah berhasil Mengalahkanku,\n sekarang ajak bicara orang di depan";

        yield return new WaitUntil(() => spacecount == 1);

        chatend.text = "test ke 2";
        yield return new WaitUntil(() => spacecount == 2);

        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        WinCondition.SetResult("Trainer1");
        SceneManager.LoadScene("GamePlay");

        yield return 0;
    }

}
