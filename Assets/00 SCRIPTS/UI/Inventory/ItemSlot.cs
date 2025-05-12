using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected string _itemName;
    [SerializeField] protected int _quantity;
    [SerializeField] protected Sprite _spriteItem;
    [SerializeField] protected string _itemDescription;

    [SerializeField] protected TMP_Text _textQuantity;
    [SerializeField] protected Image _imageItem;
    [SerializeField] public GameObject _selectedItem;
    [SerializeField] protected GameObject _useOrDeleteItem;
    public bool _checkSelected;
    public bool _isFull;

    [SerializeField] protected Image _itemImageDescription;
    [SerializeField] protected TMP_Text _itemTextDescription;
    [SerializeField] protected TMP_Text _itemNameTextDescription;
    public void AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    {
        this._itemName = itemName;
        this._quantity = quantity;
        this._spriteItem = sprite;
        this._itemDescription = itemDescription;
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
    }

    public void OnLeftClick(){
        
        InventoryManager.Instance.DeleteSelectedItem();
        _selectedItem.SetActive(true);
        _useOrDeleteItem.SetActive(true);
        _checkSelected = true;

        this._itemTextDescription.text = _itemDescription;
        this._itemNameTextDescription.text = _itemName;
        this._itemImageDescription.sprite = _spriteItem;
        if (_itemImageDescription.sprite == null)
        {
            _useOrDeleteItem.SetActive(false);
        }

    }

}
