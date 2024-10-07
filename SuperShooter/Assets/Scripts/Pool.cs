using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // We use object pooling to store objects in a pool,
    // by allocating the maximum number of objects possible,
    // we just take and return from pool. This decrease fragmentation
    // problem because of Instantiate and Destory. Object need to be
    // reinitialize with OnEnable event function when taken out. 
    List<GameObject> storedObjects = new List<GameObject>();
    [SerializeField] GameObject prefab;

    public GameObject Get()
    {
        if (storedObjects.Count > 0)
        {
            var obj = storedObjects[0];
            storedObjects.RemoveAt(0);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Instantiate(prefab);
        }
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        storedObjects.Add(obj);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
