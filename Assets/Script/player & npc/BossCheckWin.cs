using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckWin : MonoBehaviour
{

    [SerializeField] GameObject NpcAchievment;

    private void Start() 
    {
        if (WinCondition.GetResult() == name)
        {
            Debug.Log("Win");
            Instantiate(NpcAchievment);
        }    
    }
}
