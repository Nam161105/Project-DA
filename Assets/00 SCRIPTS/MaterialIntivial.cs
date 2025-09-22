using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialIntivial : MonoBehaviour
{
    protected Vector2 _tranformPos;
    protected Quaternion _tranformRot;


    private void Awake()
    {
        _tranformPos = this.transform.position;
        _tranformRot = transform.rotation;
    }

    public void Reset()
    {
        transform.position = _tranformPos;  

        transform.rotation = _tranformRot;

        this.gameObject.SetActive(true);
    }
}
