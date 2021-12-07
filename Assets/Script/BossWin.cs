using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWin : MonoBehaviour
{
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;

    public void winBossChat()
    {
        nama.text = "Boss";
        chatend.transform.parent.parent.gameObject.SetActive(true);
        chatend.text = "mantab";
        
    }
}
