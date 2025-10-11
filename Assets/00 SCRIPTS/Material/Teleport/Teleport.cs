using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] protected Transform _teleportB;
    [SerializeField] protected Animator _ani;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportAfterTime());
        }
    }


    protected IEnumerator TeleportAfterTime()
    {
        _ani.SetTrigger("min");
        yield return new WaitForSeconds(0.2f);
        PlayerController.Instance.transform.position = _teleportB.position;
        _ani.SetTrigger("max");
    }
}
