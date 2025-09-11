using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public abstract class BaseEnemys : MonoBehaviour, IDame
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
    [SerializeField] protected float _nextAtkTime = 0;
    [SerializeField] protected float _timeAniAtk;


    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;


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
            Debug.Log("enemy da chet");
            this.Die();
        }
    }


    protected abstract void Die();
    protected void TurningDirectionPlayer()
    {
        if (_enenmy.currentHp <= 0)
        {
            return;
        }
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










}
