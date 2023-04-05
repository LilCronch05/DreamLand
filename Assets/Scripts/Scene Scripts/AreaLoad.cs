using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AreaLoad : MonoBehaviour
{
    [SerializeField]
    Transform exit;
    [SerializeField]
    string areaLoadName, areaName;
    bool transition = false;
    PlayerController player;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(exit.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transition && !player.Fading())
        {
            SceneManager.LoadScene(areaLoadName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(areaName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggering");

        if (other.tag == "Player")
        {
            PlayerInfo.piInstance.spawnLocation = exit.position;
            PlayerInfo.piInstance.currentScene = areaLoadName;

            player = other.GetComponent<PlayerController>();
            player.Fade(true);
            transition = true;
        }
    }
}
