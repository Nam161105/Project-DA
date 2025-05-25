using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOfPlayer : MonoBehaviour, IDame
{
    protected static HealthBarOfPlayer instance;
    public static HealthBarOfPlayer Instance => instance;

    public DataPlayer _dataPlayer;
    [SerializeField] protected Image _imageHealth;

    [SerializeField] protected int _minAddDame;
    [SerializeField] protected int _maxAddDame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        _dataPlayer.currentHp = _dataPlayer.maxHp;
        this.UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("da mat mau");
            _dataPlayer.currentHp -= Random.Range(190, 200);
            if (_dataPlayer.currentHp <= 0)
            {
                Debug.Log("player da chet");
            }
            this.UpdateHealthBar();
        }
    }


    public void AddHealth()
    {
        _dataPlayer.currentHp += Random.Range(_minAddDame, _maxAddDame);
        if (_dataPlayer.currentHp >= _dataPlayer.maxHp)
        {
            _dataPlayer.currentHp = _dataPlayer.maxHp;
        }
        this.UpdateHealthBar();
    }
    protected void UpdateHealthBar()
    {
        _imageHealth.fillAmount = _dataPlayer.currentHp / _dataPlayer.maxHp;
    }

    public void TakDame(int minDame, int maxDame)
    {
        _dataPlayer.currentHp -= Random.Range(minDame, maxDame);
        if (_dataPlayer.currentHp <= 0)
        {
            Debug.Log("player da chet");
        }
        this.UpdateHealthBar();
    }  

    
}
