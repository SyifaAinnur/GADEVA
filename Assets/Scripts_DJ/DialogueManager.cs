using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if (sentences.Count == 0)
        {
            Debug.Log("Nothing");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PauseMenu.isPause == true)
            {
                //
            }
            if (PauseMenu.isPause == false)
            {
                DisplayNextSentence();
            }
            
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Debug.Log("Nothing");
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        if (sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        //Debug.Log(sentence);
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "DoodleJump")
        {
            //SceneManager.LoadScene("Transisi DoodleJump");
            levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadNextLevel();
        }
        if (sceneName == "Doodle Jump Wave 2")
        {
            SceneManager.LoadScene("Diisi nanti");
            
        }
    }
}
