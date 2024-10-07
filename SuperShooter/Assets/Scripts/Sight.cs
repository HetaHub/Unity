using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    // distance for vision distance, angle to determine the amplitude of view cone.
    // ObstacleLayers to check which objects are obstacles, objectsLayers to determine the
    // detect target.
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    static Collider[] colliders = new Collider[100];

    void OnDrawGizmos()
    {
        if (this.enabled)
        {
            Gizmos.color = Color.red;
            // We can use OnDrawGizmosSelected instead Gizmos to prevent too many things draw on
            // screen together, it will only show the Gizmo when we select the object.
            Gizmos.DrawWireSphere(transform.position, distance);

            Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
            // Origin, direction * distance
            Gizmos.DrawRay(transform.position, rightDirection * distance);

            Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
            Gizmos.DrawRay(transform.position, leftDirection * distance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Make collider with AI.position with radius=distance, detect objectsLayers.
        // Also can use OverlapSphereNonAlloc, which is more performant by not allocating array to result.
        //Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);

        // NonAlloc version will just alloc once and reuse whenever we need, the size of colliders array will be 100 now.
        int detectedAmount = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, objectsLayers);

        detectedObject = null;
        //for (int i = 0; i < colliders.Length; i++)
        for (int i = 0; i < detectedAmount; i++)
        {
            Collider collider = colliders[i];

            //Calculate angle between viewing angle and direction of object, if less than cone angle, we
            // considered it falls into our vision. Use collider center instead piviot because pivot is
            // in the ground and ray check may collide with it wrongly.
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            //Calculate forward vector and target direction vector angle. We can use Vector3.Dot, but need
            // to convert result back into angle, which can be an expensive calculation. If don't have 50+
            // sensors, our approach is faster.
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            // if angle is 30, it will have left and right, so it is 60 degree.
            if (angleToCollider < angle)
            {
                // create imaginary line to detect whether target will fall into our range, if no obstacles,
                // we have direct sight to target.
                // out can give us more info about what the line collided with, such as position and normal.
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers))
                {
                    // Passed 3 filters: distance, angle, raycast check. Which means we see the target.
                    // Debug Drawline will only show when in runtime.
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }

        }
    }
}
