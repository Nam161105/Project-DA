using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOfPlayer : MonoBehaviour, IDame
{
    protected static HealthBarOfPlayer instance;
    public static HealthBarOfPlayer Instance => instance;

    public DataHealth _dataPlayer;
    [SerializeField] protected Image _imageHealth;

    [SerializeField] protected int _minAddDame;
    [SerializeField] protected int _maxAddDame;

    [SerializeField] protected GameObject _textDamageUI;
    [SerializeField] protected Text _textHealth;

    [SerializeField] protected PointSpawnDie _pointSpawnDie;
    [SerializeField] protected Animator _animator;

    

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


    public void AddHealth()
    {
        _dataPlayer.currentHp += Random.Range(_minAddDame, _maxAddDame);
        if (_dataPlayer.currentHp >= _dataPlayer.maxHp)
        {
            _dataPlayer.currentHp = _dataPlayer.maxHp;
        }
        this.UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        _imageHealth.fillAmount = _dataPlayer.currentHp / _dataPlayer.maxHp;
        _textHealth.text = _dataPlayer.currentHp.ToString() + "/4000";
    }

    public void TakDame(int minDame, int maxDame)
    {
        int dame = Random.Range(minDame, maxDame);
        _dataPlayer.currentHp -= dame;
        GameObject textDamage = ObjectPool.Instance.GetObjectPrefab(_textDamageUI.gameObject);
        textDamage.GetComponent<TextMesh>().text = dame.ToString();
        textDamage.SetActive(true);
        textDamage.transform.parent = transform;
        textDamage.transform.rotation = Quaternion.identity;
        if (_dataPlayer.currentHp <= 0)
        {
            _animator.SetTrigger("Die");
            AudioManager.Instance.PlaySFX(AudioManager.Instance._playerDead);
            StartCoroutine(DieAfterTime());
        }
        this.UpdateHealthBar();
    }  


    protected IEnumerator DieAfterTime()
    {
        yield return new WaitForSeconds(2.5f);
        if (_pointSpawnDie != null)
        {
            _pointSpawnDie.RespawnRivive();
        }
    }
}
