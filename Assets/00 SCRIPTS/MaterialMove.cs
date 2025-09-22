using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMove : MonoBehaviour
{
    [SerializeField] protected float _speedRight;
    protected Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rb.AddTorque(-_speedRight);
        }
    }
}
