using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AtkLongRange : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _posInstance;
    [SerializeField] protected GameObject _enemyPos;

    protected void AtkPlayer()
    {
        GameObject bullet = ObjectPool.Instance.GetObjectPrefab(_bulletPrefab.gameObject);
        AudioManager.Instance.PlaySFX(AudioManager.Instance._shotEnemy);
        bullet.transform.position = _posInstance.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);

        Vector3 dir = _enemyPos.transform.right.x > 0 ? Vector3.right : Vector3.left;
        FireMove _fireMove = bullet.GetComponent<FireMove>();
        if (_fireMove != null)
        {
            _fireMove.SetDir(dir);
        }
    }
}
