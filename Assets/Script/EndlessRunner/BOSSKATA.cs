using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BOSSKATA : MonoBehaviour
{
    [SerializeField] private Text chatend;
    // [SerializeField] private Text nama;

    public IEnumerator winBossChat(GameObject player)
    {
        // nama.text = "Boss";
        chatend.transform.parent.gameObject.SetActive(true);
        chatend.text = "Kamu telah berhasil Menaklukan HATIKU,\n sekarang JADILAH PACARKU \ntoko";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        // player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        Debug.Log("back to main game");
        WinCondition.SetResult("Trainer2");
        SceneManager.LoadScene("GamePlay");

        yield return 0;
    }

}
