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
        foreach (Collider2D col in colli)
        {
            if (col.CompareTag("Enemy"))
            {
                IDame dame = col.GetComponent<IDame>();
                if (dame != null)
                {
                    dame.TakDame(_minDame, _maxDame);
                    this.InputTagEnemy();
                }
            }
        }
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
        if(_jAtk == 4)
        {
            _jAtk = 0;
            _imageSkill1.text = _jAtk.ToString();
        }
    }

    protected void Skill2Atk()
    {
        if (_kAtk == 3)
        {
            _kAtk = 0;
            _imageSkill2.text = _kAtk.ToString();
        }
    }

    protected void Skill3Atk()
    {
        if (_lAtk == 3)
        {
            _lAtk = 0;
            _imageSkill3.text = _lAtk.ToString();
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
