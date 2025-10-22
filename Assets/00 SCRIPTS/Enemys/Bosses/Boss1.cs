using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : BaseEnemys
{
    protected override void MoveToPlayer()
    {
        float distance = Vector2.Distance(this.transform.position, PlayerController.Instance.transform.position);
        this.TurningDirectionPlayer();
        if (distance > _distancePlayerWithEnemy)
        {
            _animator.SetTrigger("idle");
        }
        else
        {
            if (distance <= _distanceCanAtk)
            {
                if (_nextAtkTime >= _atkSpeed)
                {
                    if (HealthBarOfPlayer.Instance._dataPlayer.currentHp <= 0)
                    {
                        return;

                    }
                    StartCoroutine(AtkAfterTime());
                }
                else
                {
                    _animator.SetTrigger("idle");
                }
            }
            else
            {
                this.transform.position = Vector2.MoveTowards
                (this.transform.position, PlayerController.Instance.transform.position, _speed * Time.deltaTime);
                _animator.SetTrigger("walk");
            }
        }
        _nextAtkTime += Time.deltaTime;
    }
    protected IEnumerator AtkAfterTime()
    {
        _animator.SetTrigger("atk");
        yield return new WaitForSeconds(_timeAniAtk);
        _nextAtkTime = 0;
    }



    protected override void Die()
    {
        _animator.SetTrigger("die");
    }

}
