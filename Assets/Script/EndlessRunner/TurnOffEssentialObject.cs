using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffEssentialObject : MonoBehaviour
{

    [HideInInspector] public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        player.GetComponent<TurnGameObject>().TurnOff();
        Transisi.SetPlayer(player);
        player.SetActive(false);
        //Debug.Log(player.name);
    }

    // Update is called once per frame
}
