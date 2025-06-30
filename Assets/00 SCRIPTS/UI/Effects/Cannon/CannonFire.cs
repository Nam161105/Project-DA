using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] protected GameObject _fireBullet;
    [SerializeField] protected GameObject _pointInstanceBullet;
    protected CannonDirection _cannonDir;
    protected Animator _ani;


    private void Awake()
    {
        _cannonDir = GetComponent<CannonDirection>();
        _ani = GetComponent<Animator>();
    }

    public void Start()
    {
        StartCoroutine(AtkAfterTime());
    }

    public IEnumerator AtkAfterTime()
    {
        yield return new WaitForSeconds(0.6f);
        _ani.SetTrigger("fire");
        yield return new WaitForSeconds(1f);
        _ani.SetTrigger("end");
    }

    public void FireBulletSkill2()
    {
        GameObject enemy = _cannonDir.FindEnemyAtk();
        if (enemy != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance._cannonFire);

            Vector2 dir = enemy.transform.position - _pointInstanceBullet.transform.position;

            GameObject g = ObjectPool.Instance.GetObjectPrefab(_fireBullet.gameObject);
            g.transform.position = _pointInstanceBullet.transform.position;
            g.transform.rotation = Quaternion.identity;
            g.SetActive(true);

            FireEffectMove fire = g.GetComponent<FireEffectMove>();
            if (fire != null)
            {
                fire.SetDir(dir);
            }
        }
    }
}
