using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedneeded;
    public bool inPlay;
    public Transform paddle;
    public Transform particle;
    public GameManager gm;
    public Transform powerup;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        // rb.AddForce(Vector2.up * speedneeded);
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameover == true){
            return;
        }
        if(inPlay == false){
            transform.position = paddle.position;
        }

        if(Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            rb.AddForce(Vector2.up * speedneeded);

        }
    }

    //wat hapen kalau kena trigger bawah
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("bottom")){
            // Debug.Log("bola masuk bawah");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    //wat happen kalau nabrak box
    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.CompareTag("brick")){
            //baru sampe sini
            Brick brick = other.gameObject.GetComponent<Brick>();
            if(brick.hitToBreak > 1){
                brick.BreakBrick();
            }

            else{
                int randomChance = Random.Range(1,101);
                if(randomChance < 50){
                Instantiate(powerup, other.transform.position, other.transform.rotation); 
                }
                
                //manggil partikel
                Transform newParticle= Instantiate(particle, other.transform.position,other.transform.rotation);
                
                //agar gak berbekas tambah transform newparticle
                Destroy (newParticle.gameObject, 2.5f);

                gm.UpdateScore(brick.points);
                gm.UpdateNumberOfBrick();
                if (other.collider.name == "Boss") {

                    Destroy(other.collider.transform.parent.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
            audio.Play();
        }
       
    }
    public void CheckVelocity()
    {
        // Prevent ball from rolling in the same directon forever
        if (rb.velocity.x == 0)
        {
            rb.velocity = new Vector2(Random.Range(1, 3), rb.velocity.y);
        }
        else if (rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(1, 3));
        }
    }
}
