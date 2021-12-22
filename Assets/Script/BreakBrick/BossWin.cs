using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossWin : MonoBehaviour
{
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;

    [SerializeField] private GameObject pauseObj;

    public IEnumerator winBossChat(GameObject player)
    {
        pauseObj.SetActive(false);
        nama.text = "Boss";
        chatend.transform.parent.parent.gameObject.SetActive(true);
        chatend.text = "Kamu telah berhasil Mengalahkanku,\n sekarang ajak bicara orang di depan \ntoko";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        WinCondition.SetResult("Trainer1");
        SceneManager.LoadScene("GamePlay");

        yield return 0;
    }

}
