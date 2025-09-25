using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{

    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected GameObject _pointInstance;
    public void AtkEnemy()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance._monster);
        GameObject g = ObjectPool.Instance.GetObjectPrefab(_bulletPrefab.gameObject);
        g.SetActive(true);
        g.transform.position = _pointInstance.transform.position;
        g.transform.rotation = Quaternion.identity;
    }
}
