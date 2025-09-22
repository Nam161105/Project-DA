using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] protected List<MaterialIntivial> materialIntivials;

    public void ResetMaterial()
    {
        foreach (var material in materialIntivials)
        {
            material.Reset();
        }
    }
}
