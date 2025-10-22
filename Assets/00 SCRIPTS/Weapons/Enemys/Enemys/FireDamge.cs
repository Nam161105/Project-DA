using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamge : MonoBehaviour
{
    [SerializeField] protected int _minDamage;
    [SerializeField] protected int _maxDamage;
    [SerializeField] protected GameObject _explosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDame dame = collision.gameObject.GetComponent<IDame>();
            if (dame != null )
            {
                dame.TakDame(_minDamage, _maxDamage);
                this.gameObject.SetActive(false);
                this.InstanceEffect();
            }
        }
    }

    protected void InstanceEffect()
    {
        GameObject explosion = ObjectPool.Instance.GetObjectPrefab(_explosionEffect.gameObject);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = Quaternion.identity;
        explosion.SetActive(true);
    }
}
