using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_HitBox, Treasure;
    [SerializeField]
    private Image m_HealthBar;
    NavMeshAgent agent;
    public float m_MaxHealth = 100.0f;
    public float health = 100.0f;
    public Transform player;
    public Transform[] waypoints;
    private int currentWaypoint;
    float timer;
    bool isInRange;

    Animator enemyAnim;

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
        m_HealthBar.gameObject.GetComponent<RectTransform>().localScale = new Vector3(health / m_MaxHealth, 1, 1);

        if (agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
            enemyAnim.SetBool("isMoving", true);
        }

        

        if (isInRange || health < 100)
        {
            agent.SetDestination(player.position);
            enemyAnim.SetBool("isSprinting", true);
            //speed up the enemy
            agent.speed = 4.0f;
        }

        //once they have reached the player, they will attack
        if (player.position == agent.destination)
        {
            enemyAnim.SetBool("isAttacking", true);
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                player.GetComponent<PlayerController>().health -= 5.0f;
                timer = 0.0f;
            }
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            //Treasure.SetActive(true);
            enemyAnim.SetBool("isDead", true);
            Destroy(gameObject);
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
