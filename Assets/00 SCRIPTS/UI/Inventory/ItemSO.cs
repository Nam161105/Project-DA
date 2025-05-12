using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Items")]
public class ItemSO : ScriptableObject
{
    public string _itemName;
    public stateItem _stateItem = new stateItem();

    public void UseItem()
    {

    }

    public enum stateItem
    {
        None,
        Health,
        Mana,

    }
}
