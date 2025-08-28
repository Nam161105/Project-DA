using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour
{
    Texture2D texture;
    [SerializeField] protected int _pixelPerUnit;
    protected float _inWidth;
    protected float _inHeight;

    private void Start()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
        _inWidth = texture.width / _pixelPerUnit;
        _inHeight = texture.height / _pixelPerUnit;
    }

    private void Update()
    {
        this.BGLoop();
    }

    protected void BGLoop()
    {
        if (Mathf.Abs(PlayerController.Instance.transform.position.x - this.transform.position.x) >= _inWidth)
        {
            Vector3 pos = this.transform.position;
            pos.x = PlayerController.Instance.transform.position.x;
            this.transform.position = pos;
        }

        if (Mathf.Abs(PlayerController.Instance.transform.position.y - this.transform.position.y) >= _inHeight)
        {
            Vector3 pos = this.transform.position;
            pos.y = PlayerController.Instance.transform.position.y;
            this.transform.position = pos;
        }
    }
}
