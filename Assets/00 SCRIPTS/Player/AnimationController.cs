using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;

public class AnimationController : MonoBehaviour
{
    protected Animator _ani;

    private void Start()
    {
        _ani = GetComponent<Animator>();
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
