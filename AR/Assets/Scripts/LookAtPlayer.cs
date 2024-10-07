using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance == null)
        {
            return;
        }
        // Enemy will look at player.
        transform.forward = PlayerManager.instance.transform.position - transform.position;
    }
}
