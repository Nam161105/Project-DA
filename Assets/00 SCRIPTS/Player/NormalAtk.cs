using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalAtk : MonoBehaviour
{
    [SerializeField] protected Transform _pointAtk;
    [SerializeField] protected float _rangeAtk;
    [SerializeField] protected LayerMask _enemy;
    [SerializeField] protected int _minDame;
    [SerializeField] protected int _maxDame;

    public void AttackSkill1()
    {
        Collider2D[] colli = Physics2D.OverlapCircleAll(_pointAtk.transform.position, _rangeAtk, _enemy);
        foreach (Collider2D col in colli)
        {
            if (col.CompareTag("Enemy"))
            {
                IDame dame = col.GetComponent<IDame>();
                if (dame != null)
                {
                    dame.TakDame(_minDame, _maxDame);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pointAtk.transform.position, _rangeAtk);
    }
}
