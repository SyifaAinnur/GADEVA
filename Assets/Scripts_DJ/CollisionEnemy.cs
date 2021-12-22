using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //GameOver();
            //isStarted = false;
            HealthTextScript.healthAmount -= 1;
            Destroy(collision.gameObject);
        }
    }
}
