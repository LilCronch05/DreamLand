using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    //Seting up NPC interaction
    private GameObject npcInteract;
    private bool isInteracting;
    public GameObject m_NpcInteractText;
    public GameObject m_NpcOptionText1;
    public GameObject m_NpcOptionText2;
    public GameObject npcDialog1;
    public GameObject npcDialog2;
    public GameObject npcDialog3;
    public GameObject quest1;
    public GameObject questComplete;
    public GameObject m_AvailableQuest;
    public GameObject m_QuestLocator;
    
    //Setting up player score
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        quest1.SetActive(false);
        questComplete.SetActive(false);
        m_QuestLocator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            m_NpcInteractText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F) && score <= 6)
            {
                m_NpcInteractText.SetActive(false);
                npcDialog1.SetActive(true);
                m_NpcOptionText1.SetActive(true);
                m_NpcOptionText2.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                npcDialog1.SetActive(false);
                npcDialog2.SetActive(true);

                //Heal the player to full health
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().m_MaxHealth;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                quest1.SetActive(true);
                m_AvailableQuest.SetActive(false);
                m_QuestLocator.SetActive(true);
                npcDialog1.SetActive(false);
                npcDialog3.SetActive(true);

                scoreText.text = score.ToString();

                questComplete.SetActive(false);
            }   
        }
        else
        {
            m_NpcInteractText.SetActive(false);
            m_NpcOptionText1.SetActive(false);
            npcDialog1.SetActive(false);
            npcDialog2.SetActive(false);
            npcDialog3.SetActive(false);
        }

        if (score >= 6)
        {
            quest1.SetActive(false);
            questComplete.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = true;
            npcInteract = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = false;
            npcInteract = null;
        }
    }
}
