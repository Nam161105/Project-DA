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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject GetObjectPrefab(GameObject defaultPrefab)
    {
        if (!_listObjPrefab.ContainsKey(defaultPrefab))
        {
            _listObjPrefab.Add(defaultPrefab, new List<GameObject>());
        }

        for (int i = _listObjPrefab[defaultPrefab].Count - 1; i >= 0; i--)
        {
            GameObject obj = _listObjPrefab[defaultPrefab][i];

            // Cần thiết: Kiểm tra xem đối tượng có null không (tức là đã bị hủy)
            if (obj == null)
            {
                // Nếu đối tượng đã bị hủy, hãy xóa nó khỏi danh sách
                _listObjPrefab[defaultPrefab].RemoveAt(i);
            }
            else if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(defaultPrefab);
        _listObjPrefab[defaultPrefab].Add(newObj);

        newObj.transform.parent = this.transform;

        return newObj;
    }
}
