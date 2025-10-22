using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlying : MonoBehaviour
{
    [SerializeField] protected Transform _pointStart;
    [SerializeField] protected Transform _pointEnd;
    [SerializeField] protected float _speed;
    [SerializeField] protected bool _isMove = false;

    private void Update()
    {
        this.MoveAroundTwoPoint();
    }

    protected void MoveAroundTwoPoint()
    {
        if (Vector3.Distance(transform.position, _pointStart.position) <= 2f)
        {
            _isMove = true;
        }
        else if (Vector3.Distance(transform.position, _pointEnd.position) <= 2f)
        {
            _isMove = false;
        }

        if (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointEnd.position, _speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointStart.position, _speed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
