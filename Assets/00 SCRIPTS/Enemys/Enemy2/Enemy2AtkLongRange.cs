using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AtkLongRange : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _posInstance;

    protected void AtkPlayer()
    {
        GameObject bullet = ObjectPool.Instance.GetObjectPrefab(_bulletPrefab.gameObject);
        bullet.transform.position = _posInstance.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);

    }
}
