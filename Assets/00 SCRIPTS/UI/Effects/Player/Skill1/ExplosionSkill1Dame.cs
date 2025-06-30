using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkill1Dame : MonoBehaviour
{
    [SerializeField] protected int _minDamage;
    [SerializeField] protected int _maxDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance._explosionSkill2);
            IDame dame = collision.gameObject.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakDame(_minDamage, _maxDamage);
            }
        }
    }
}
