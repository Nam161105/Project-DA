using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActive : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(ObjectActiveAfterTime());
    }

    protected IEnumerator ObjectActiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
