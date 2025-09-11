using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDie : MonoBehaviour
{
    protected Vector3 _lastPointDie;
    protected float _lastHealth;


    private void Start()
    {
        _lastPointDie = transform.position;
        _lastHealth = HealthBarOfPlayer.Instance._dataPlayer.currentHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointSpawnDie"))
        {
            _lastPointDie = collision.transform.position;
            _lastHealth = HealthBarOfPlayer.Instance._dataPlayer.currentHp;
        }
    }

    public void RespawnRivive()
    {
        transform.position = _lastPointDie;
        HealthBarOfPlayer.Instance._dataPlayer.currentHp = _lastHealth;
        HealthBarOfPlayer.Instance.UpdateHealthBar();
    }
}
