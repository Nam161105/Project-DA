using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected string _itemName;
    [SerializeField] protected int _quantity;
    [SerializeField] protected Sprite _spriteItem;

    [SerializeField] protected TMP_Text _textQuantity;
    [SerializeField] protected Image _imageItem;
    [SerializeField] public GameObject _selectedItem;
    public bool _checkSelected;
    public bool _isFull;


    public void AddItem(string itemName, int quantity, Sprite sprite)
    {
        this._itemName = itemName;
        this._quantity = quantity;
        this._spriteItem = sprite;
        _isFull = true;

        _textQuantity.text = _quantity.ToString();
        _textQuantity.enabled = true;
        _imageItem.sprite = _spriteItem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            this.OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            this.OnRightClick();
        }
    }

    public void OnLeftClick(){
        InventoryManager.Instance.DeleteSelectedItem();
        _selectedItem.SetActive(true);
    }

    protected void OnRightClick()
    {

    }

}
