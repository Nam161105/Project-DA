using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDame : MonoBehaviour
{
    [SerializeField] protected int _minDame;
    [SerializeField] protected int _maxDame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDame dame = collision.gameObject.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakDame(_minDame, _maxDame);
            }
            this.gameObject.SetActive(false);
        }
    }
}
