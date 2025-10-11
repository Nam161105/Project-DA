using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoveGround : MonoBehaviour
{
    public static event Action _moveGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MoveAfterTime());
        }
    }

    protected IEnumerator MoveAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        _moveGround?.Invoke();
        this.gameObject.SetActive(false);
    }
}
