using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//unity enggine ui buat manggil ui ui
using UnityEngine.SceneManagement;
//untuk scene scene pakai Scenemanagement


public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text scoreText;
    public Text livesText;
    public bool gameover;
    public GameObject gameoverpanel;
    public int brickall;
    private GameObject player;

    private SoundManager soundManager;
    [SerializeField] private DialogueMid win;
    [SerializeField] private Pause pausebtn;
    [SerializeField] private BossWin bosswin;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");

        //ngatur text dalem tanpa ngisi boxnya
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        brickall = GameObject.FindGameObjectsWithTag("brick").Length;
        Time.timeScale = 1;
        player = FindObjectOfType<PlayerController>().gameObject;
        soundManager = FindObjectOfType<SoundManager>();
        player.SetActive(false);
        player.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log(player.transform.parent.name);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausebtn.StartPause();
        }
    }

    //function penagturan lives
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //cek untuk habis nyawa
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    //function pengfaturan score
    public void UpdateScore(int points)
    {
        score += points;

        //cek untuk habis nyawa
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBrick()
    {
        brickall--;
        //Debug.Log(brickall);
        if (brickall <= 0)
        {

            Win();
        }
    }
    void Win()
    {
        //start coroutine untuk menjalankan ienumerator
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main"))
        {

            player.SetActive(true);
            player.transform.GetChild(0).gameObject.SetActive(true);
            win.StartCoroutine(win.Dialogue());
        }
        else
        {


            bosswin.StartCoroutine(bosswin.winBossChat(player));


        }

    }
    void GameOver()
    {
        gameover = true;

        //menyalakan panel
        gameoverpanel.SetActive(true);
    }

    //function untuk main lagi
    public void PlayAgain()
    {
        player.SetActive(true);
        player.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("Route1");
        //cekl apakah work
        Debug.Log("game Keluar");
    }
}
