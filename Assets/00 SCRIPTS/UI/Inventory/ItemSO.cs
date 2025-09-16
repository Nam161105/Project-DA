using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Items")]
public class ItemSO : ScriptableObject
{
    public string _itemName;
    public stateItem _stateItem = new stateItem();
    [SerializeField] protected int _minDame;
    [SerializeField] protected int _maxDame;

    public void UseItem()
    {
        if(_stateItem == stateItem.Health)
        {
            HealthBarOfPlayer.Instance.AddHealth();
        }
        if (_stateItem == stateItem.Speed)
        {
            PlayerController.Instance.AddSpeed();
        }
    }

    public enum stateItem
    {
        None,
        Health,
        Speed,

    }
}
