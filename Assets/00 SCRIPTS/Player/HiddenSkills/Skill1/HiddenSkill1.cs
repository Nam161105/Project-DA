using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSkill1 : MonoBehaviour
{
    [SerializeField] protected GameObject _explosionPrefab;


    public void HiddenSkill1Atk(Vector3 lastPos)
    {
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_explosionPrefab.gameObject);
        g.gameObject.SetActive(true);
        g.transform.position = lastPos;
        g.transform.rotation = Quaternion.identity;
        AudioManager.Instance.PlaySFX(AudioManager.Instance._explosionSkill1);
    }
}
