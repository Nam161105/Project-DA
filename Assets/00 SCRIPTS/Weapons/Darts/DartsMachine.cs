using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsMachine : MonoBehaviour
{
    [SerializeField] protected float _rangePlayer;
    [SerializeField] protected LayerMask _playerMask;
    [SerializeField] protected GameObject _darts;
    [SerializeField] protected float _coolDown;
    protected float coolDown = 0;

    private void Update()
    {
        coolDown += Time.deltaTime;
        Collider2D[] phy = Physics2D.OverlapCircleAll(transform.position, _rangePlayer, _playerMask);
        foreach (Collider2D col in phy)
        {
            if (col.gameObject.CompareTag("Player") && coolDown >= _coolDown)
            {
                coolDown = 0;
                GameObject g = ObjectPool.Instance.GetObjectPrefab(_darts.gameObject);
                g.SetActive(true);
                g.transform.position = transform.position;
                g.transform.rotation = Quaternion.identity;
            }
        }
    }


    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _rangePlayer);
        Gizmos.color = Color.red;
    }
}
