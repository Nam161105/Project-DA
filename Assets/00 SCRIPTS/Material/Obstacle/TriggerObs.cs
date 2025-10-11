using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObs : MonoBehaviour
{
    [SerializeField] protected GameObject _obs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _obs.gameObject.SetActive(true);
        }
    }
}
