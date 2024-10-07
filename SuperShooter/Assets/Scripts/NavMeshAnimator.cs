using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAnimator : MonoBehaviour
{
    // We get the velocity from NavMeshAgent and set it to the animator, it is similar to 
    // VelocityAnimator, but because NavMeshAgent has its own velocity system, we don't use
    // Rigidbody to move. So we can set Rigidbody to kinematic, because it don't move with Physics.
    Animator animator;
    NavMeshAgent agent;
    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", agent.velocity.magnitude);
    }
}
