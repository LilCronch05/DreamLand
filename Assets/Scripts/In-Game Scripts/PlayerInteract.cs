using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    //Seting up NPC interaction
    private GameObject npcInteract;
    private bool isInteracting;
    public GameObject npcText;
    public GameObject npcText2;
    public GameObject npcDialog1;
    public GameObject npcDialog2;
    public GameObject npcDialog3;
    public GameObject quest1;
    public GameObject questComplete;
    public GameObject questMarker;
    
    //Setting up player score
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        quest1.SetActive(false);
        questComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            npcText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F) && score <= 6)
            {
                npcText.SetActive(false);
                npcDialog1.SetActive(true);
                npcText2.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.E) && score <= 6)
            {
                quest1.SetActive(true);
                npcDialog1.SetActive(false);
                npcDialog2.SetActive(true);

                scoreText.text = score.ToString() + " Ducks Gathered";
            }
            else if(Input.GetKeyDown(KeyCode.F) && score >= 6)
            {
                questMarker.SetActive(false);
                npcDialog1.SetActive(false);
                npcDialog2.SetActive(false);
                npcDialog3.SetActive(true);
                questComplete.SetActive(false);
            }   
        }
        else
        {
            npcText.SetActive(false);
            npcText2.SetActive(false);
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
        if (other.gameObject.tag == "NPC")
        {
            isInteracting = true;
            npcInteract = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            isInteracting = false;
            npcInteract = null;
        }
    }
}
