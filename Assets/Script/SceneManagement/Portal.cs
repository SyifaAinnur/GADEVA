using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint;

    PlayerController player;
    public void OnPlayerTriggerd(PlayerController player)
    {
        this.player = player;
        if (name == "PortalEnding")
        {
            if (player.inventory.slots.Count < 3)
            {
                return;
            }
        }
        StartCoroutine(SwitchScene());
    }

    Fader fader;
    private void Start() 
    {
        fader = FindObjectOfType<Fader>();  
    }

    IEnumerator SwitchScene()
    {
        DontDestroyOnLoad(gameObject);

        GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);

        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        var destPortal = FindObjectsOfType<Portal>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.Character.SetPositionAndSnapToTile(destPortal.spawnPoint.position);

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);

        Destroy(gameObject);
    }

    public Transform SpawnPoint
    {
        get
        {
            return spawnPoint;
        }
    }
}

public enum DestinationIdentifier {
    A,B, C, D, E
}
