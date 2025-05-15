using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    protected static InventoryManager instance;
    public static InventoryManager Instance => instance;

    [SerializeField] protected GameObject _inventoryMenu;
    [SerializeField] protected bool _checkActiveMenu;

    [SerializeField] protected ItemSlot[] _itemSlot;
    protected bool _isFull;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Update()
    {
        this.InputInventory();

    }

    protected void InputInventory()
    {
        if (Input.GetKeyDown(KeyCode.W) && !_checkActiveMenu)
        {
            _inventoryMenu.SetActive(true);
            _checkActiveMenu = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && _checkActiveMenu)
        {
            _inventoryMenu.SetActive(false);
            _checkActiveMenu = false;
        }
    }

    public int AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            if (_itemSlot[i]._isFull == false && _itemSlot[i]._itemName == itemName || _itemSlot[i]._quantity == 0)
            {
                int leftOverItems =  _itemSlot[i].AddItem(itemName, quantity, sprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, sprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeleteSelectedItem()
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            _itemSlot[i]._selectedItem.gameObject.SetActive(false);
            _itemSlot[i]._checkSelected = false;
        }
    }
}
