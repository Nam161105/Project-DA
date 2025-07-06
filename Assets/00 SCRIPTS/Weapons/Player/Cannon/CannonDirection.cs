using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDirection : MonoBehaviour
{
    [SerializeField] protected float _atkRange;
    [SerializeField] protected LayerMask _enemyLayerMask;
    protected Collider2D[] hits;


    private void Update()
    {
        //this.FindEnemyAtk();
    }

    public GameObject FindEnemyAtk()
    {
        hits = Physics2D.OverlapCircleAll(this.transform.position, _atkRange, _enemyLayerMask);

        GameObject enemy = null;
        float shortestDis = Mathf.Infinity;
        foreach (Collider2D hit in hits)
        {
            float dir = Vector2.Distance(this.transform.position, hit.transform.position);
            if(dir < shortestDis)
            {
                shortestDis = dir;
                enemy = hit.gameObject;
                Vector2 dir2 = this.transform.position - hit.transform.position;
                float angle = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg + 180;
                this.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            
        }
        return enemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, _atkRange);
    }
}
