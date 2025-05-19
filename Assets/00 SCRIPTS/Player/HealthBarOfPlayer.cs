using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOfPlayer : MonoBehaviour
{
    public DataPlayer _dataPlayer;
    [SerializeField] protected Image _imageHealth;

    private void Start()
    {
        _dataPlayer.currentHp = _dataPlayer.maxHp;
        this.UpdateHealthBar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("da mat mau");
            _dataPlayer.currentHp -= 100;
            if (_dataPlayer.currentHp <= 0)
            {
                Debug.Log("player da chet");
            }
            this.UpdateHealthBar();
        }
    }

    protected void UpdateHealthBar()
    {
        _imageHealth.fillAmount = _dataPlayer.currentHp / _dataPlayer.maxHp;
    }
}
