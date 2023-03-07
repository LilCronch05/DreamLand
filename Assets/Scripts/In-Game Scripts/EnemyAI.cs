using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public float health = 100.0f;
    public Transform player;
    public Transform[] waypoints;
    private int currentWaypoint;
    float timer;
    bool isInRange;

    public Animator enemyAnim;

    void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWaypoint].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
            enemyAnim.SetBool("isMoving", true);
        }

        if (health <= 0)
        {
            enemyAnim.SetBool("isDead", true);
            Destroy(gameObject, 2.0f);
        }

        if (isInRange || health < 100)
        {
            agent.SetDestination(player.position);
            enemyAnim.SetBool("isSprinting", true);
        }

        //once they have reached the player, they will attack
        if (agent.remainingDistance < 1.5f)
        {
            enemyAnim.SetBool("isAttacking", false);
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                player.GetComponent<PlayerController>().health -= 10.0f;
                timer = 0.0f;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
}
