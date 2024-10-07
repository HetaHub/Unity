using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer };
    public EnemyState currentState;
    public Sight sightSensor;
    Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    NavMeshAgent agent;
    public GameObject bulletPrefab;
    public float fireRate;
    float lastShootTime;
    public GameObject shootPoint;
    Animator animator;


    void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        // We will look for the component in gameobject, if not there, try look in all parent.
        // Also have GetComponentInChildren(), which searches the gameobject, then the children.
        agent = GetComponentInParent<NavMeshAgent>();
        // Cache reference to parent Animator.
        animator = GetComponentInParent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if (currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        else if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else if (currentState == EnemyState.AttackPlayer)
        {
            AttackPlayer();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    void GoToBase()
    {
        animator.SetBool("Shooting", false);
        agent.isStopped = false;
        // give the base position for the target.
        agent.SetDestination(baseTransform.position);
        // if detected sth when going to base, switch to chase player.
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase <= baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }
    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }
    void ChasePlayer()
    {
        animator.SetBool("Shooting", false);
        agent.isStopped = false;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer()
    {
        agent.isStopped = true;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void Shoot()
    {
        // Everytime we shoot, turn on animator. Then turn off in non-shooting states, such as chasePlayer and GoToBase.
        animator.SetBool("Shooting", true);
        if (Time.timeScale > 0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
            {
                return;
            }

            lastShootTime = Time.time;
            //Instantiate(bulletPrefab, transform.position, transform.rotation);
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }

    // The enemy will face the target direction and shoot bullet even stopped, such as when attacking base or player.
    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        // Set y component to 0 to prevent upward/ downward rotation.
        directionToPosition.y = 0;
        // Set the parent forward vector to face the target position. To have a smooth rotation, we can use quaternions.
        transform.parent.forward = directionToPosition;
    }
}
