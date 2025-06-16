using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemys : MonoBehaviour
{
    [Header("---DataEnemy---")]
    public DataHealth _enenmy;

    [Header("---Enemy Move---")]
    [SerializeField] protected float _speed;
    [SerializeField] protected GameObject _playerPos;

    [Header("Aniamtion")]
    protected Animator _animator;

    [Header("Time Atk")]
    [SerializeField] protected float _atkSpeed;
    protected float _nextAtkTime;
    [SerializeField] protected float _timeAniAtk;

    [Header("Distance with Player")]
    [SerializeField] protected float _distancePlayerWithEnemy;
    [SerializeField] protected float _distanceCanAtk;



    private void Start()
    {
        _enenmy.currentHp = _enenmy.maxHp;
        _animator = GetComponent<Animator>();
        _nextAtkTime = _atkSpeed;
    }

    private void Update()
    {
        if(_enenmy.currentHp <= 0)
        {
            _animator.SetTrigger("die");
            return;
        }
        this.MoveToPlayer();
        this.TurningDirectionPlayer();
    }

    protected void MoveToPlayer()
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
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    

}
