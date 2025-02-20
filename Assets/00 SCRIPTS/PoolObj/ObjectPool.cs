using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    protected static ObjectPool instance;
    public static ObjectPool Instance => instance;
    [SerializeField] protected Dictionary<GameObject, List<GameObject>> _listObjPrefab = 
        new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject GetObjectPrefab(GameObject defaultPrefab)
    {
        if (_listObjPrefab.ContainsKey(defaultPrefab))
        {
            foreach(GameObject obj in _listObjPrefab[defaultPrefab])
            {
                if (obj.activeSelf)
                {
                    continue;
                } 
                return obj;
            }
            GameObject _g = Instantiate(defaultPrefab, transform.position, Quaternion.identity);
            _listObjPrefab[defaultPrefab].Add(_g);
            _g.SetActive(false);
            return _g;
        }

        List<GameObject> list = new List<GameObject>();
        GameObject g = Instantiate(defaultPrefab, transform.position, Quaternion.identity); 
        list.Add(g);
        _listObjPrefab.Add(defaultPrefab, list);
        g.SetActive(false);
        return g;
    }
}
