using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    [SerializeField] protected GameObject _monster;

    private void OnEnable()
    {
        _monster.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(InstanceMonsterAfterTime());
        }
    }

    protected IEnumerator InstanceMonsterAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        _monster.gameObject.SetActive(true);
        this.gameObject.SetActive(false);   
    }
}
