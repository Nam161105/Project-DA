using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSkill2 : MonoBehaviour
{
    [SerializeField] protected GameObject _explosionHiddenSkill2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DameEneyAfterTime());
        }
    }

    protected IEnumerator DameEneyAfterTime()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_explosionHiddenSkill2.gameObject);
        g.SetActive(true);
        g.transform.position = transform.position;
        g.transform.rotation = Quaternion.identity;
        this.gameObject.SetActive(false);
    }
}
