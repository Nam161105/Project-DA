using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NormalAtk : MonoBehaviour
{
    [Header("Range Atk")]
    [SerializeField] protected Transform _pointAtk;
    [SerializeField] protected float _rangeAtk;
    [SerializeField] protected LayerMask _enemy;

    [Header("dame")]
    [SerializeField] protected int _minDame;
    [SerializeField] protected int _maxDame;

    [Header("Check Input")]
    [SerializeField] protected int _jAtk = 0;
    [SerializeField] protected int _kAtk = 0;
    [SerializeField] protected int _lAtk = 0;
    protected KeyCode _lastKey = KeyCode.None;

    [Header("Update UI skill")]
    [SerializeField] protected Text _imageSkill1;
    [SerializeField] protected Text _imageSkill2;
    [SerializeField] protected Text _imageSkill3;

    protected Vector3 _lastPos;
    protected HiddenSkill1 _hiddenSkill1;
    [SerializeField] protected CannonFire _hiddenSkill2;

    [SerializeField] protected DataHealth _enemy1;
    [SerializeField] protected DataHealth _enemy2;

    private void Start()
    {
        _hiddenSkill1 = GetComponent<HiddenSkill1>();
    }

    void Update()
    {
        this.CheckInput();
    }

    protected void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _lastKey = KeyCode.J;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            _lastKey = KeyCode.K;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            _lastKey = KeyCode.L;
        }
    }

    public void AttackSkill1()
    {
        Collider2D[] colli = Physics2D.OverlapCircleAll(_pointAtk.transform.position, _rangeAtk, _enemy);
        Vector3 currentPos = Vector3.zero;
        foreach (Collider2D col in colli)
        {
            if (col.CompareTag("Enemy"))
            {
                IDame dame = col.GetComponent<IDame>();
                if (dame != null)
                {
                    dame.TakDame(_minDame, _maxDame);
                    currentPos = col.transform.position;
                    this.InputTagEnemy();
                }
            }
        }
        _lastPos = currentPos;
        _lastKey = KeyCode.None;
    }

    protected void InputTagEnemy()
    {
        switch (_lastKey)
        {
            case KeyCode.J:
                AudioManager.Instance.PlaySFX(AudioManager.Instance._normalAtk1);
                _jAtk++;
                _imageSkill1.text = _jAtk.ToString();
                this.Skill1Atk();
                break;
            case KeyCode.K:
                AudioManager.Instance.PlaySFX(AudioManager.Instance._normalAtk2);
                _kAtk++;
                _imageSkill2.text = _kAtk.ToString();
                this.Skill2Atk();
                break;
            case KeyCode.L:
                AudioManager.Instance.PlaySFX(AudioManager.Instance._normalAtk3);
                _lAtk++;
                _imageSkill3.text = _lAtk.ToString();
                this.Skill3Atk();
                break;
            case KeyCode.None:
                Debug.LogWarning("Warning");
                break;
        }
    }


    protected void Skill1Atk()
    {
        if(_jAtk >= 3)
        {
            _jAtk = 0;
            _imageSkill1.text = _jAtk.ToString();
            if (_enemy1.currentHp <= 0 && _enemy2.currentHp <= 0)
            {
                return;
            }
            StartCoroutine(HiddenSkill1AfterTime());
        }
    }

    protected IEnumerator HiddenSkill1AfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        _hiddenSkill1.HiddenSkill1Atk(_lastPos);
    }
    protected void Skill2Atk()
    {
        if (_kAtk >= 2)
        {
            _kAtk = 0;
            _imageSkill2.text = _kAtk.ToString();
            if (_enemy1.currentHp <= 0 || _enemy2.currentHp <= 0)
            {
                return;
            }
            _hiddenSkill2.FireAtk();
        }
    }

    protected void Skill3Atk()
    {
        if (_lAtk >= 1)
        {
            _lAtk = 0;
            _imageSkill3.text = _lAtk.ToString();
            if (_enemy1.currentHp <= 0 || _enemy2.currentHp <= 0)
            {
                return;
            }
            BatAtk.Instance.Atk();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (_pointAtk != null)
        {
            Gizmos.DrawWireSphere(_pointAtk.transform.position, _rangeAtk);
        }
    }
}
