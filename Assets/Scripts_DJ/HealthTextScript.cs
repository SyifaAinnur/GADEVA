using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{
    public Text text;
    public static int healthAmount = 50;
    public Controller_W2 controller;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        healthAmount = 50;
}

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            healthAmount = 0;
            controller = FindObjectOfType<Controller_W2>();
            controller.GameOver();
            this.enabled = false;
        }

        text.text = healthAmount.ToString();

        
    }
}
