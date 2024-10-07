using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnerPlacer : MonoBehaviour
{
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject spawnerPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This instantiate a prefab at the place player tapped in the AR Raycast system.
        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, hits))
        {
            Instantiate(spawnerPrefab, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
}
