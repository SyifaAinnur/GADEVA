using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainerController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    Character character;

    public void Interact(Transform initiator)
    {
        character.LookTowards(initiator.position);

        StartCoroutine(DialogManager.Instance.ShowDialog(dialog, () =>
        {
            SceneManager.LoadScene("main");

            
        }));
    }

    private void Awake()
    {
        character = GetComponent<Character>();
    }


}
