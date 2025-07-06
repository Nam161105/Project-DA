using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        this.MoveBullet();
    }

    protected void MoveBullet()
    {
        GameObject enemy = BatAtk.Instance.FindEnemy();
        transform.position = Vector3.MoveTowards(this.transform.position, enemy.transform.position
            , _speed);
    }


}
