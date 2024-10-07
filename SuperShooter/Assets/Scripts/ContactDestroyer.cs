using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    // Collider type will indicate the type of collider that hit us.
    // Or we can use onCollisionEnter.
    void OnTriggerEnter(Collider other)
    {
        if (this.enabled){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
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
