using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : BaseEnemys, IDame
{

    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;

    public void TakDame(int minDame, int maxDame)
    {
        int dame = Random.Range(minDame, maxDame);
        GameObject textDame = ObjectPool.Instance.GetObjectPrefab(_textDameUI.gameObject);
        textDame.GetComponent<TextMesh>().text = dame.ToString();
        textDame.transform.parent = transform;
        textDame.transform.rotation = Quaternion.identity;
        textDame.SetActive(true);
        _enenmy.currentHp -= dame;
        if (_enenmy.currentHp <= 0)
        {
            this.Die();
        }
    }

    protected void Die()
    {
        _animator.SetTrigger("die");
    }

}
