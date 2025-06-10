using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Atk : MonoBehaviour
{
    [SerializeField] protected Transform _pointAtk;
    [SerializeField] protected float _rangeAtk;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected int _minDamage;
    [SerializeField] protected int _maxDamage;
    protected Collider2D[] hits;

    public void AtkPlayer()
    {
        hits = Physics2D.OverlapCircleAll(_pointAtk.position, _rangeAtk, layerMask);
        foreach (Collider2D c in hits)
        {
            if (c.CompareTag("Player"))
            {
                IDame dame = c.gameObject.GetComponent<IDame>();
                if (dame != null)
                {
                    dame.TakDame(_minDamage, _maxDamage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_pointAtk.position, _rangeAtk);
    }
}
