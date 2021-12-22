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
        player.SetActive(false);
    }

    // Update is called once per frame
}
