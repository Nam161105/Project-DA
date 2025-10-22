using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1 : MonoBehaviour
{
    [SerializeField] protected int _minDamage;
    [SerializeField] protected int _maxDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDame dame = collision.gameObject.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakDame(_minDamage, _maxDamage);
                this.gameObject.SetActive(false);
            }
        }
    }
}
