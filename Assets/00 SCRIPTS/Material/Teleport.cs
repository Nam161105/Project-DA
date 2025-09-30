using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] protected Transform _teleportB;
    [SerializeField] protected Animator _ani;

    private void Update()
    {
        float dis = Vector3.Distance(this.transform.position, PlayerController.Instance.transform.position);
        if(dis <= 2f)
        {
            StartCoroutine(TeleportAfterTime());
        }
    }

    protected IEnumerator TeleportAfterTime()
    {
        _ani.SetTrigger("min");
        yield return new WaitForSeconds(0.2f);
        PlayerController.Instance.transform.position = _teleportB.position;
        _ani.SetTrigger("max");
    }
}
