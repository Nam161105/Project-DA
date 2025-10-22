using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    protected Rigidbody2D _rb;
    [SerializeField] protected float _speed;
    protected Vector3 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetDir(Vector3 dir)
    {
        _direction = dir.normalized;
    }
    private void Update()
    {
        this.MoveBullet();
    }

    protected void MoveBullet()
    {
        _rb.velocity = _speed * _direction;
    }
}
