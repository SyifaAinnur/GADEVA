using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndless : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    [SerializeField] GameObject winPannel;
    [SerializeField] DialogueMidEndless Dialogue;
    [SerializeField] GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float directionY = Input.GetAxisRaw("Vertical");
       playerDirection = new Vector2(0,directionY).normalized;
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Side Borders (1)")
        {
            Time.timeScale = 0f; 
            winPannel.SetActive(true);
            pauseButton.SetActive(false);
            Dialogue.StartCoroutine(Dialogue.Dialogue());
        }
    }

    
}
