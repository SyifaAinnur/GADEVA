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
    private int bouncecount;
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
        CheckVelocity();
        if (other.transform.CompareTag("brick")){
            //baru sampe sini
            Brick brick = other.gameObject.GetComponent<Brick>();
            if(brick.hitToBreak > 1){
                brick.BreakBrick();
            }

            else{
                int randomChance = Random.Range(0, 100);
                if(randomChance < 10){
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
        Debug.Log("exe");
        // Prevent ball from rolling in the same directon forever
        if (rb.velocity.x == 0)
        {
            
            bouncecount++;
            if(bouncecount >= 2)
            {
                if (Random.Range(0,2) == 0) {
                    rb.velocity = new Vector2(2, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-2, rb.velocity.y);
                }
                bouncecount = 0;
            }
        }
        else if (rb.velocity.y == 0)
        {
            bouncecount++;
            if (bouncecount >= 2)
            {
                if(Random.Range(0, 2) == 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 2);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, -2);
                }
                bouncecount = 0;
            }
            
        }
        else
        {
            bouncecount = 0;
        }
    }
}
