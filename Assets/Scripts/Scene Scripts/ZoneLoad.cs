using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ZoneLoad : MonoBehaviour
{
    [SerializeField]
    Transform m_Destination;
    [SerializeField]
    string areaLoadName, areaName, m_DestinationName;
    bool transition = false;
    PlayerController player;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (transition && !player.Fading())
        {
            SceneManager.LoadScene(areaLoadName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(areaName);

            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(m_Destination.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Destination = GameObject.FindGameObjectWithTag(m_DestinationName).transform;

            PlayerInfo.piInstance.spawnLocation = m_Destination.position;
            PlayerInfo.piInstance.currentScene = areaLoadName;

            player = other.GetComponent<PlayerController>();
            player.Fade(true);
            transition = true;
        }
    }
}
