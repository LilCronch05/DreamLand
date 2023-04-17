using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ZoneLoad : MonoBehaviour
{
    [SerializeField]
    Transform exit;
    [SerializeField]
    string areaLoadName, areaName, Destination;
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

            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(exit.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            exit = GameObject.FindGameObjectWithTag(Destination).transform;

            PlayerInfo.piInstance.spawnLocation = exit.position;
            PlayerInfo.piInstance.currentScene = areaLoadName;

            player = other.GetComponent<PlayerController>();
            player.Fade(true);
            transition = true;
        }
    }
}
