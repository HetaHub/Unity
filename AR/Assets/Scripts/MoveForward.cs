using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Because LookAtPlayer already facing player, we just move the z axis.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
