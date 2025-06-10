using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    protected BoxCollider2D box;
    [SerializeField] protected float _offsetX;
    [SerializeField] protected float _offsetY;
    [SerializeField] protected float _sizeX;
    [SerializeField] protected float _sizeY;

    private void Start()
    {
         box = GetComponent<BoxCollider2D>();
    }

    protected void ChangeBoxCollider()
    {
        if (box != null)
        {
            box.offset = new Vector2(_offsetX, _offsetY);
            box.size = new Vector2(_sizeX, _sizeY);
        }
    }
}
