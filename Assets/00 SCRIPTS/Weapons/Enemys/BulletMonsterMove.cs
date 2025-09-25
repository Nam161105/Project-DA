using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonsterMove : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        this.MoveBullet();
    }

    protected void MoveBullet()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.Instance.transform.position
            , _speed);
    }
}
