using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int amount;

    void OnTriggerEnter(Collider other)
    {
        // ? means the variable can be nullable. Example shows below:
        // FileInfo fi = ...; // fi could be null
        // long? length = fi?.Length; // If fi is null, length will be null
        other.GetComponent<Life>()?.Damage(amount);
        Destroy(gameObject);
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
