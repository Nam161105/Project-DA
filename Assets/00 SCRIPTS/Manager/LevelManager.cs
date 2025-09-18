using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    protected static LevelManager instance;
    public static LevelManager Instance => instance;
    [SerializeField] protected float _currentExp;
    [SerializeField] protected float _maxExp;
    [SerializeField] protected Text _levelText;
    [SerializeField] protected Image _imageLv;
    protected int level = 1;

    public event Action<int> DamePerLevel;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(AddExpPerSecond());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LevelUp(15);
        }
    }

    public void LevelUp(int expAdd)
    {
        if (level == 15)
        {
            return;
        }
        _currentExp += expAdd;
        UpdateUI();
        if (_currentExp >= _maxExp)
        {
            _currentExp = 0;
            _maxExp += 20;
            level++;
            DamePerLevel?.Invoke(level);
            _levelText.text = "LV: " + level.ToString();
            UpdateUI();
        }


    }

    protected IEnumerator AddExpPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int expAdd = 3;
            LevelUp(expAdd);
        }
    }

    protected void UpdateUI()
    {
        _imageLv.fillAmount = _currentExp / _maxExp;
    }
}
