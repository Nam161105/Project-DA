using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] protected List<LoopBG> _loopBG = new List<LoopBG>();    
    [SerializeField] protected List<float> _speed = new List<float>();
    int _dirPlayer;

    private void Update()
    {
        this.ParallaxBG();
    }

    protected void ParallaxBG()
    {
        if (PlayerController.Instance._PlayerState == PlayerController.PlayerState.Idle)
        {
            return;
        }
        _dirPlayer = PlayerController.Instance.transform.right.x > 0 ? -1 : 1;
        for (int i = 0; i < _loopBG.Count; i++)
        {
            _loopBG[i].transform.position += new Vector3(_dirPlayer * _speed[i] * Time.deltaTime, 0, 0);
        }
    }
}
