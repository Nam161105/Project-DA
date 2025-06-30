using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectMove : MonoBehaviour
{
    protected Rigidbody2D _rb;
    [SerializeField] protected float _speed;
    protected Vector2 _dir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.MoveEffect();
    }

    public void SetDir(Vector2 direction)
    {
        _dir = direction.normalized;
    }
    protected void MoveEffect()
    {
        _rb.velocity = _dir * _speed;  
    }
}
