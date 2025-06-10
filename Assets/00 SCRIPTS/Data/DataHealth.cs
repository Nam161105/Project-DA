using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Data")]
public class DataHealth : ScriptableObject
{
    public float maxHp;
    public float currentHp;
}
