using System.Collections;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] protected Transform _pointFinish;
    [SerializeField] protected float _speed;
    private bool _isMoving = false;

    private void OnEnable()
    {
        TriggerMoveGround._moveGround += StartMoving;
    }

    private void OnDisable()
    {
        TriggerMoveGround._moveGround -= StartMoving;
    }

    protected void StartMoving()
    {
        if (!_isMoving)
        {
            StartCoroutine(MoveGroundCoroutine());
            _isMoving = true;
        }
    }

    protected IEnumerator MoveGroundCoroutine()
    {
        while (transform.position != _pointFinish.transform.position)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _pointFinish.transform.position,
                _speed * Time.deltaTime
            );

            yield return null;
        }
        _isMoving = false;
    }
}