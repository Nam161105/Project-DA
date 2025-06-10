using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamePopUp : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(ActiceAfterTime());
    }

    protected IEnumerator ActiceAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
