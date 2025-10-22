using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialIntivial : MonoBehaviour
{
    protected Vector3 initialPosition;
    protected Quaternion initialRotation;
    protected bool initialActive;

    [SerializeField] protected bool deactiveObj = false;

    protected virtual void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialActive = gameObject.activeSelf;
    }

    public virtual void Reset()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        if (deactiveObj)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(initialActive);
        }
    }
}
