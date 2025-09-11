using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected GameObject _ground;
    [SerializeField] protected GameObject _ground2;
    [SerializeField] protected Transform _point1;
    [SerializeField] protected Transform _point2;
    [SerializeField] protected Transform _point3;
    [SerializeField] protected Transform _point4;

    private void OnEnable()
    {
        Obstacle._groundMove += MoveGround;
        Obstacle._groundMove2 += MoveGround2;
    }

    private void OnDisable()
    {
        Obstacle._groundMove -= MoveGround;
        Obstacle._groundMove2 -= MoveGround2;
    }

    protected void MoveGround()
    {
        _ground.transform.position = Vector3.MoveTowards(_point1.transform.position, _point2.transform.position, 1f * Time.deltaTime);
    }

    protected void MoveGround2()
    {
        _ground2.transform.position = Vector3.MoveTowards(_point3.transform.position, _point4.transform.position, 1f * Time.deltaTime);
    }
}
