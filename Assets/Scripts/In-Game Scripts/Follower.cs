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
    TextMeshProUGUI m_InteractText;
    bool m_IsFollowing;
    bool m_IsInteracting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        m_InteractText = GameObject.FindGameObjectWithTag("InteractText").GetComponent<TextMeshProUGUI>();

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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsInteracting = true;
        }
    }
}
