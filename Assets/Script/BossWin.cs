using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossWin : MonoBehaviour
{
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;

    public IEnumerator winBossChat(GameObject player)
    {
        nama.text = "Boss";
        chatend.transform.parent.parent.gameObject.SetActive(true);
        chatend.text = "mantab";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");

        yield return 0;
    }

}
