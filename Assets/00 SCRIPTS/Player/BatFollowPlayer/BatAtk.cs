using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAtk : MonoBehaviour
{
    protected static BatAtk instance;   
    public static BatAtk Instance => instance;
    [SerializeField] protected float _rangeFind;
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected GameObject _pointInstance;
    Collider2D[] hits;
    Animator _ani;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _ani = GetComponent<Animator>();
    }

    public void Atk()
    {
        StartCoroutine(AtkAfterTime()); 
    }

    protected IEnumerator AtkAfterTime()
    {
        _ani.SetTrigger("atk");
        yield return new WaitForSeconds(0.1f);
        _ani.SetTrigger("fly");

    }
    public void AtkEnemy()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance._batClip);
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_bulletPrefab.gameObject);
        g.SetActive(true);
        g.transform.position = _pointInstance.transform.position;
        g.transform.rotation = Quaternion.identity;
    }
    public GameObject FindEnemy()
    {
        hits = Physics2D.OverlapCircleAll(transform.position, _rangeFind, _layerMask);
        GameObject enemy = null;
        float shortDistest = Mathf.Infinity;

        foreach (Collider2D c in hits)
        {
            float dis = Vector2.Distance(transform.position, c.transform.position);
            if(dis < shortDistest)
            {
                shortDistest = dis;
                enemy = c.gameObject;
            }
        }
        return enemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, _rangeFind);
    }

}
