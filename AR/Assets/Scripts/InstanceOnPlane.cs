using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InstanceOnPlane : MonoBehaviour
{
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    ARRaycastManager raycastManager;
    public GameObject prefab;
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse is emulated as touching in touch screen, we can also use Input.touches.
        // RaycastManager will throw a raycast to the player touching position and store the hits inside the list,
        // it return true if hit.
        if (Input.GetKeyDown(KeyCode.Mouse0) && raycastManager.Raycast(Input.mousePosition, hits))
        {
            // Instantiate prefab on the first hit position.
            Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
}
