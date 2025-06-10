using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : BaseEnemys, IDame
{

    [Header("Text Dame")]
    [SerializeField] protected GameObject _textDameUI;
    [SerializeField] protected Enemy1Atk _enemy1Atk;

    public void TakDame(int minDame, int maxDame)
    {
        int dame = Random.Range(minDame, maxDame);
        GameObject textDame = ObjectPool.Instance.GetObjectPrefab(_textDameUI.gameObject);
        textDame.GetComponent<TextMesh>().text = dame.ToString();
        textDame.transform.position = transform.position;
        textDame.transform.rotation = Quaternion.identity;
        textDame.transform.parent = transform;
        textDame.SetActive(true);
        _enenmy.currentHp -= dame;
        if (_enenmy.currentHp <= 0)
        {
            this.Die();
            Debug.Log("Enemy da chet");
        }
    }

    protected void Die()
    {
        _animator.SetTrigger("die");
        this.gameObject.GetComponent<EnemyMove>().enabled = false;
    }

}
