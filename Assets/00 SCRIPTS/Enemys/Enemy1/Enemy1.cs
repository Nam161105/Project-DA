using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy1 : BaseEnemys
{

    [Header("Instance Item After Die")]
    [SerializeField] protected GameObject _item;
    [SerializeField] protected float _lifeTime;



    protected override void MoveToPlayer()
    {
        float distance = Vector2.Distance(this.transform.position, _playerPos.transform.position);
        this.TurningDirectionPlayer();
        if (distance > _distancePlayerWithEnemy)
        {
            _animator.SetTrigger("idle");
        }
        else
        {
            if (distance <= _distanceCanAtk)
            {
                if (_nextAtkTime >= _atkSpeed)
                {
                    StartCoroutine(AtkAfterTime());
                }
                else
                {
                    _animator.SetTrigger("idle");
                }
            }
            else
            {
                this.transform.position = Vector2.MoveTowards
                (this.transform.position, _playerPos.transform.position, _speed * Time.deltaTime);
                _animator.SetTrigger("walk");
            }
        }
        _nextAtkTime += Time.deltaTime;
    }

    protected IEnumerator AtkAfterTime()
    {
        _animator.SetTrigger("atk");
        yield return new WaitForSeconds(_timeAniAtk);
        _nextAtkTime = 0;
    }

    

    protected override void Die()
    {
        _animator.SetTrigger("die");
        StartCoroutine(InstanceItemAfterTime());
    }

    protected IEnumerator InstanceItemAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_item.gameObject);
        g.SetActive(true) ;
        g.transform.position = transform.position;
        g.transform.rotation = Quaternion.identity;
    }

}
