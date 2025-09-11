using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected GameObject _openText;
    [SerializeField] protected GameObject _openText2;
    [SerializeField] protected Text _colorText;

    public static event Action _groundMove;

    public static event Action _groundMove2;


    private void Update()
    {
        if(Vector2.Distance(transform.position, _openText.transform.position) <= 2.5f)
        {
            StartCoroutine(ChangeColorText());
        }

        if (Vector2.Distance(transform.position, _openText2.transform.position) <= 2f)
        {
            StartCoroutine(ChangeColorText2());
        }
    }

    protected IEnumerator ChangeColorText()
    {
        yield return new WaitForSeconds(1);
        _colorText.color = Color.white;
        _openText.GetComponent<Text>().color = Color.white;
        _groundMove?.Invoke();
    }

    protected IEnumerator ChangeColorText2()
    {
        yield return new WaitForSeconds(1);
        _colorText.color = Color.red;
        _openText2.GetComponent<Text>().color = Color.red;
        _groundMove2?.Invoke();
    }
}
