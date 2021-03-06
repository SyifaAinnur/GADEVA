using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BOSSKATA : MonoBehaviour
{

    private int spacecount = 0;

    private bool process = false;
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }

    public IEnumerator winBossChat(GameObject player)
    {
        process = true;
        nama.text = "Boss";
        // nama.text = "Boss";
        chatend.transform.parent.gameObject.SetActive(true);
        chatend.text = "Kamu telah berhasil Mengalahkanku,\n sekarang ajak bicara orang di depan";

        yield return new WaitUntil(() => spacecount == 1);

        chatend.text = "test ke 2";
        yield return new WaitUntil(() => spacecount == 2);

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
