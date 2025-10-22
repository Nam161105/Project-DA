using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsMove : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Vector3 _dir;
    protected Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dir = (PlayerController.Instance.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        _rb.velocity = _dir * _speed;
    }
}
