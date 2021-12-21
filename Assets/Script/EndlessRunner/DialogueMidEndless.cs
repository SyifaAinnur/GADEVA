using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueMidEndless : MonoBehaviour
{
    // [SerializeField] private Text nama;
    [SerializeField] private Text dialog;
    [SerializeField] private GameObject paneldialog;
    private int spacecount = 0;
    private bool process = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }
    public IEnumerator Dialogue()
    {
        paneldialog.SetActive(true);
        process = true;
        // nama.text = "Boss";
        dialog.text = "Sial, kau terlalu kuat ";
        //yield return untuk memulai urutan/antrian(tidak tereksekusi bila tidak kena trigger)
        yield return new WaitUntil (()=> spacecount == 1);
        dialog.text = "Ya sudah, LAWAN AKU SAJA!!!! ";
        yield return new WaitUntil (()=> spacecount == 2);
        SceneManager.LoadScene("Wave 2");
    }


}
