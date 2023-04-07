using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Follower : MonoBehaviour
{
    [SerializeField]
    Transform m_Target;
    [SerializeField]
    Transform m_Destination;
    [SerializeField]
    TextMeshProUGUI m_InteractText;
    private NavMeshAgent m_Agent;
    bool m_IsFollowing;
    bool m_IsInteracting;
    bool m_IsHome;

    public static Follower fiInstance = null;
    public string currentScene;

    public Animator m_FollowerAnim;

    private void Awake()
    {
        if (fiInstance == null)
        {
            fiInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (fiInstance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_FollowerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsInteracting)
        {
            m_InteractText = GameObject.FindGameObjectWithTag("InteractText").GetComponent<TextMeshProUGUI>();

            m_InteractText.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_IsFollowing = true;
                m_IsInteracting = false;
            }
        }

        if (m_IsFollowing)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
            
            m_Agent.SetDestination(m_Target.position);
            m_InteractText.text = "";
        }

        if (m_IsHome)
        {
            m_IsFollowing = false;
            m_IsInteracting = false;

            m_Destination = GameObject.FindGameObjectWithTag("Destination").transform;
            m_Agent.SetDestination(m_Destination.position);
        }

        if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
        {
            m_FollowerAnim.SetBool("isMovingFWD", false);
        }
        else
        {
            m_FollowerAnim.SetBool("isMovingFWD", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            m_IsInteracting = true;
        }

        if (other.tag == "Home")
        {
            
            m_IsHome = true;
        }
    }
}
