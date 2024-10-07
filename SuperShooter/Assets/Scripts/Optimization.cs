using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this is executed by compiler, which can exclude many codes when compiling if conditions not met. 
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        print("This won't show up in log.");
#endif
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        print("This will show up in log.");
#endif
    }
}
