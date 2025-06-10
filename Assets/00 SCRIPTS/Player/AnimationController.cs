using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;

public class AnimationController : MonoBehaviour
{
    protected Animator _ani;
    [SerializeField] protected NormalAtk _enemyBase;
    [SerializeField] protected NormalAtk _enemyBase2;
    [SerializeField] protected NormalAtk _enemyBase3;

    private void Start()
    {
        _ani = GetComponent<Animator>();

    }

    public void TakeDamageEvent()
    {
        _enemyBase.AttackSkill1();
    }
    public void TakeDamageEvent2()
    {
        _enemyBase2.AttackSkill1();
    }
    public void TakeDamageEvent3()
    {
        _enemyBase3.AttackSkill1();
    }

    public void UpdateAnimation(PlayerState playerState)
    {
        for(int i = 0;i <= (int)PlayerState.Run; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if(playerState == (PlayerState)i)
            {
                _ani.SetBool(stateName, true);
            }
            else
            {
                _ani.SetBool(stateName, false);
            }
        }
    }

    
}
