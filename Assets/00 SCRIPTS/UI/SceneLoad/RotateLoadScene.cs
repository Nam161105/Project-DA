using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateLoadScene : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
