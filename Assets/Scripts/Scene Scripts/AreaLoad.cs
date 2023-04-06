using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AreaLoad : MonoBehaviour
{
    [SerializeField]
    string areaName;
    bool transition = false;
    PlayerController player;

    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(exit.position);
        player.Fade(false);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggering");

        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(areaName, LoadSceneMode.Additive);

            PlayerInfo.piInstance.currentScene = areaName;

            player = other.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.UnloadSceneAsync(areaName);
        }
    }
}
