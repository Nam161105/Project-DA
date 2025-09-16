using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string _itemName;
    [SerializeField] public int _quantity;
    [SerializeField] public Sprite _spriteItem;
    [TextArea(3, 10)]
    [SerializeField] public string _itemDescriptionText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance._itemPicked);
            this.gameObject.SetActive(false);

            int leftOverItems = InventoryManager.Instance.AddItem(_itemName, _quantity, _spriteItem, _itemDescriptionText);
            if(leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _quantity = leftOverItems;
            }
            
        }
    }
}
