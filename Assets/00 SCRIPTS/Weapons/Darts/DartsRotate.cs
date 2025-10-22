using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsRotate : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        transform.Rotate(0, 0, _speed);
    }
}
