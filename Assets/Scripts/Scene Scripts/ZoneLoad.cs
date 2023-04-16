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
    string areaLoadName, areaName;
    bool transition = false;
    PlayerController player;

    void Start()
    {
        exit = GameObject.FindGameObjectWithTag("Destination").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        

        if (transition && !player.Fading())
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(exit.position);

            //SceneManager.LoadSceneAsync(areaLoadName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(areaName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(areaLoadName, LoadSceneMode.Additive);

            PlayerInfo.piInstance.spawnLocation = exit.position;
            PlayerInfo.piInstance.currentScene = areaLoadName;

            player = other.GetComponent<PlayerController>();
            player.Fade(true);
            transition = true;
        }
    }
}
