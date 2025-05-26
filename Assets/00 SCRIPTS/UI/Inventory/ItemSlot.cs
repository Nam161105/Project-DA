using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public string _itemName;
    [SerializeField] public int _quantity;
    [SerializeField] public Sprite _spriteItem;
    [SerializeField] public string _itemDescription;

    [SerializeField] protected TMP_Text _textQuantity;
    [SerializeField] protected Image _imageItem;
    [SerializeField] public GameObject _selectedItem;
    public bool _checkSelected;
    public bool _isFull;

    [SerializeField] protected Image _itemImageDescription;
    [SerializeField] protected TMP_Text _itemTextDescription;
    [SerializeField] protected TMP_Text _itemNameTextDescription;

    [SerializeField] protected int _maxSlotItems;
    public int AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    {
        if (_isFull)
        {
            return quantity;
        }
        //update ten
        this._itemName = itemName;

        //ipdate image
        this._spriteItem = sprite;
        _imageItem.sprite = _spriteItem;

        //update mo ta
        this._itemDescription = itemDescription;
        

        this._quantity += quantity;
        if (this._quantity >= _maxSlotItems)
        {
            _textQuantity.text = _maxSlotItems.ToString();
            _textQuantity.enabled = true;
            _isFull = true;

            int leftOverItem = this._quantity - _maxSlotItems;
            this._quantity = leftOverItem;
            return leftOverItem;

        }
        
        _textQuantity.text = this._quantity.ToString();
        _textQuantity.enabled = true;

        return 0;
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

    protected void OnLeftClick(){
        if (_checkSelected)
        {
            if(this._quantity > 0)
            {
                InventoryManager.Instance.UseItem(_itemName);
            }

            this._quantity -= 1;
            _textQuantity.text = this._quantity.ToString();

            if (this._quantity <= 0)
            {
                this.DeleteItem();  
            }

        }
        
        
            InventoryManager.Instance.DeleteSelectedItem();
            _selectedItem.SetActive(true);
            _checkSelected = true;

            this._itemTextDescription.text = _itemDescription;
            this._itemNameTextDescription.text = _itemName;
            this._itemImageDescription.sprite = _spriteItem;

        if (this._quantity <= 0)
        {
            this._itemTextDescription.text = "";
            this._itemNameTextDescription.text = "";
            this._itemImageDescription.sprite = null;
        }



    }

    protected void OnRightClick()
    {
        if (_checkSelected)
        {
            this._quantity -= 1;
            _textQuantity.text = this._quantity.ToString();
            if (this._quantity <= 0)
            {
                this.DeleteItem();
            }
        }
    }

    protected void DeleteItem()
    {
        InventoryManager.Instance.DeleteSelectedItem();
        this._quantity = 0;

        _textQuantity.enabled = false;
        _imageItem.sprite = null;

        this._itemTextDescription.text = "";
        this._itemNameTextDescription.text = "";
        this._itemImageDescription.sprite = null;
    }

}
