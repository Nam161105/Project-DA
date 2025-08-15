using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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

    protected virtual void Update()
    {
        if(_enenmy.currentHp <= 0)
        {
            _animator.SetTrigger("die");
            return;
        }
        this.MoveToPlayer();
    }

    protected abstract void MoveToPlayer();

    


    

    



}
