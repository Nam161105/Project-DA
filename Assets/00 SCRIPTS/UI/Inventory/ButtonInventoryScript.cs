using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventoryScript : MonoBehaviour
{

    [SerializeField] protected GameObject _inventoryMenu;
    public void ButtonActiveInventory()
    {
        _inventoryMenu.SetActive(true);
    }

    public void ButtonDeActiveInventory()
    {
        _inventoryMenu.SetActive(false);
    }
}
