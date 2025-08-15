using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseEnemys, IDame
{
    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;

    [SerializeField] protected LayerMask _groundLayerMask;
    protected Rigidbody2D _rb;
    protected Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void MoveToPlayer()
    {
        Vector2 dir = (transform.right - transform.up).normalized;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 4f, _groundLayerMask);
        Debug.DrawRay(this.transform.position, dir * 4f, Color.yellow);
        if (hit.collider != null)
        {
            _movement = _rb.velocity;
            _movement.x = _speed * transform.right.x;
            _movement.y = _rb.velocity.y;
            _rb.velocity = _movement;
            _animator.SetTrigger("walk");
            Debug.Log("binh thuong");
        }
        else
        {
            _rb.velocity = Vector2.zero;
            Vector3 currentDir = transform.eulerAngles;
            currentDir.y += 180f;
            transform.eulerAngles = currentDir;
            Debug.Log("quay mat");
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
    }
}
