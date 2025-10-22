using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemys : MonoBehaviour, IDame
{
    [Header("---HealthEnemy---")]
    [SerializeField] protected float _currentHp;
    [SerializeField] protected float _maxHp;

    [Header("---Enemy Move---")]
    [SerializeField] protected float _speed;

    [Header("Aniamtion")]
    protected Animator _animator;

    [Header("Time Atk")]
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected float _nextAtkTime = 0;
    [SerializeField] protected float _timeAniAtk;


    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;


    [Header("Distance with Player")]
    [SerializeField] protected float _distancePlayerWithEnemy;
    [SerializeField] protected float _distanceCanAtk;
    protected bool _isDie = false;


    protected virtual void OnEnable()
    {
        _currentHp = _maxHp;
        _animator = GetComponent<Animator>();
        _nextAtkTime = _atkSpeed;
    }

    private void Start()
    {
        _currentHp = _maxHp;
        _animator = GetComponent<Animator>();
        _nextAtkTime = _atkSpeed;
    }

    protected virtual void Update()
    {
        if(_currentHp <= 0)
        {
            _animator.SetTrigger("die");
            return;
        }
        this.MoveToPlayer();
    }

    protected abstract void MoveToPlayer();

    public void TakDame(int minDame, int maxDame)
    {
        if (_isDie) return;
        int dame = Random.Range(minDame, maxDame);
        GameObject textDame = ObjectPool.Instance.GetObjectPrefab(_textDameUI.gameObject);
        textDame.GetComponent<TextMesh>().text = dame.ToString();
        textDame.transform.parent = transform;
        textDame.transform.rotation = Quaternion.identity;
        textDame.SetActive(true);
        _currentHp -= dame;
        if (_currentHp <= 0)
        {
            _isDie = true;
            this.Die();
        }
    }


    protected abstract void Die();
    protected void TurningDirectionPlayer()
    {
        if (_currentHp <= 0)
        {
            return;
        }
        float direction = PlayerController.Instance.transform.position.x - transform.position.x;

        if (direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (direction >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }










}
