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
    GameObject m_Destination;
    [SerializeField]
    TextMeshProUGUI m_InteractText;
    bool m_IsFollowing;
    bool m_IsInteracting;

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
        m_FollowerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        m_InteractText = GameObject.FindGameObjectWithTag("InteractText").GetComponent<TextMeshProUGUI>();
        m_Destination = GameObject.FindGameObjectWithTag("Destination");

        if (m_IsInteracting)
        {
            m_InteractText.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_IsFollowing = true;
                m_IsInteracting = false;
            }
        }
        else
        {
            m_InteractText.text = "";
        }

        if (m_IsFollowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Target.position, 5 * Time.deltaTime);
            m_InteractText.text = "";
            m_FollowerAnim.Play("isWalking");
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
            m_IsFollowing = false;
            m_Target = m_Destination.transform;
        }
    }
}
