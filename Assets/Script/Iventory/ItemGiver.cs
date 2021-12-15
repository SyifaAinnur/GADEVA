using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] ItemBase item;
    [SerializeField] Dialog dialog;


    public IEnumerator GiveItem(PlayerController player)
    {
        yield return DialogManager.Instance.ShowDialog(dialog);
        //add item to inventory
        Debug.Log("give item" + item.ItemName);
        player.inventory.AddItem(item);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return DialogManager.Instance.ShowDialogText($"Gadeva Mendapatkan {item.ItemName}");
        gameObject.SetActive(false);
    }

    public bool CanBeGiven()
    {
        return item != null;
    }
}
