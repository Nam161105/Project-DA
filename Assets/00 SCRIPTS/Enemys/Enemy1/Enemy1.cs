using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy1 : BaseEnemys, IDame
{

    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;

    [Header("Instance Item After Die")]
    [SerializeField] protected GameObject _item;
    [SerializeField] protected float _lifeTime;

    protected override void Update()
    {
        base.Update();
        this.TurningDirectionPlayer();
    }
    protected override void MoveToPlayer()
    {
        float distance = Vector2.Distance(this.transform.position, _playerPos.transform.position);
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

    protected virtual IEnumerator AtkAfterTime()
    {
        _animator.SetTrigger("atk");
        yield return new WaitForSeconds(_timeAniAtk);
        _nextAtkTime = 0;
    }
    protected void TurningDirectionPlayer()
    {
        float direction = _playerPos.transform.position.x - transform.position.x;

        if (direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (direction >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void TakDame(int minDame, int maxDame)
    {
        int dame = Random.Range(minDame, maxDame);
        GameObject textDame = ObjectPool.Instance.GetObjectPrefab(_textDameUI.gameObject);
        textDame.GetComponent<TextMesh>().text = dame.ToString();
        textDame.transform.parent = transform;
        textDame.transform.rotation = Quaternion.identity;
        textDame.SetActive(true);
        _enenmy.currentHp -= dame;
        if (_enenmy.currentHp <= 0)
        {
            this.Die();
        }
    }

    protected void Die()
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
        Debug.Log("gameobject dc sinh ra lan 1");
    }

}
