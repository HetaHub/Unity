using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public float speed;
    // 2 ways to initialize private, serializefield no need to assign the value again.
    // only expose value to editor.
    // [SerializeField]
    // private float speed;
    [SerializeField] float speed;

    void Start()
    {
        print("test start");
    }

    // Update is called once per frame
    void Update()
    {
        print(speed);
    }
}
