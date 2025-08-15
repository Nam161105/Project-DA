using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] protected PlayerController _playerPos;
    [SerializeField] protected float _offsetX;
    [SerializeField] protected float _offsetY;
    [SerializeField] protected float _speed;

    private void Update()
    {
        this.MoveWithPlayer();
    }

    protected void MoveWithPlayer()
    {
        if (_playerPos.transform.eulerAngles == new Vector3(0, 0, 0))
        {
            transform.localScale = new Vector3(1, 1, 1);
            Vector3 playerPos = _playerPos.transform.position + new Vector3(_offsetX, _offsetY);
            Vector3 speed = Vector3.Lerp(transform.position, playerPos, _speed);
            transform.position = speed;
        }
        else if (_playerPos.transform.eulerAngles == new Vector3(0, 180, 0))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Vector3 playerPos = _playerPos.transform.position + new Vector3(-_offsetX, _offsetY);
            Vector3 speed = Vector3.Lerp(transform.position, playerPos, _speed);
            transform.position = speed;
        }
    }
}
