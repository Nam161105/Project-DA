using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseEnemys
{
    [Header("Instance Item After Die")]
    [SerializeField] protected GameObject _healthItem;
    [SerializeField] protected float _lifeTime;

    [SerializeField] protected LayerMask _groundLayerMask;
    protected Rigidbody2D _rb;
    protected Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    protected override void MoveToPlayer()
    {
        float distance = Vector2.Distance(this.transform.position, PlayerController.Instance.transform.position);
        if (distance > _distancePlayerWithEnemy)
        {
            this.MoveAroundGround();
        }
        else
        {
            if (distance <= _distanceCanAtk)
            {
                _rb.velocity = Vector2.zero;
                this.Atk();
            }
            else
            {
                this.MoveAroundGround();
            }
        }
        _nextAtkTime += Time.deltaTime;
    }

    protected void MoveAroundGround()
    {
        Vector2 dir = (transform.right - transform.up).normalized;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 3.5f, _groundLayerMask);
        Debug.DrawRay(this.transform.position, dir * 3.5f, Color.red);
        if (hit.collider != null)
        {
            _movement = _rb.velocity;
            _movement.x = _speed * transform.right.x;
            _movement.y = _rb.velocity.y;
            _rb.velocity = _movement;
            _animator.SetTrigger("walk");
        }
        else 
        {
            Vector3 currentDir = transform.eulerAngles;
            currentDir.y += 180f;
            transform.eulerAngles = currentDir;
        }
    }

    protected void Atk()
    {
        if(_currentHp < _maxHp)
        {
            StartCoroutine(AtkAfterTime());
        }
        else
        {
            this.MoveAroundGround();
        }
        _nextAtkTime += Time.deltaTime;

    }

    protected IEnumerator AtkAfterTime()
    {
        yield return new WaitForSeconds(0.2f);
        if (_nextAtkTime >= _atkSpeed)
        {
            this.TurningDirectionPlayer();
            StartCoroutine(AtkAniAfterTime());
        }
        else
        {
            _animator.SetTrigger("idle");
        }
    }


    protected IEnumerator AtkAniAfterTime()
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
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_healthItem.gameObject);
        g.SetActive(true);
        g.transform.position = transform.position;
        g.transform.rotation = Quaternion.identity;
    }
}
