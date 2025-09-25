using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialIntivial : MonoBehaviour
{
    protected Vector3 initialPosition;
    protected Quaternion initialRotation;
    protected bool initialActive;

    [SerializeField] protected bool deactiveObj = false;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialActive = gameObject.activeSelf;
    }

    public void Reset()
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
