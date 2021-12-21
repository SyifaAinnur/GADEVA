
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    [SerializeField] private GameObject[] BGM; 
    [SerializeField] private GameObject[] SFX;

    private bool BGMbool = true;
    private bool SFXbool = true;

    public void SetBGM()
    {
        BGMbool = !BGMbool;
        foreach (GameObject item in BGM)
        {
            item.SetActive(BGMbool);
        }
    }

    public void SetSFX()
    {
        SFXbool = !SFXbool;
        foreach (GameObject item in SFX)
        {
            item.SetActive(SFXbool);
        }
    }
}
