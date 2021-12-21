using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void Update()
    {
        if(GetComponent <Rigidbody2D>().velocity.x < 0 ) Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Boss")
        {
            collision.GetComponent <boss> ().kenaHatimu();
            Destroy(this.gameObject);
        }
    }
}
