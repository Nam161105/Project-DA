using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string _itemName;
    [SerializeField] protected int _quantity;
    [SerializeField] protected Sprite _spriteItem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(_itemName, _quantity, _spriteItem);
            Destroy(gameObject);
        }
    }
}
