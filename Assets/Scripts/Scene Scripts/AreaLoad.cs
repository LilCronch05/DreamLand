using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AreaLoad : MonoBehaviour
{
    [SerializeField]
    string areaName;
    PlayerController player;

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(areaName, LoadSceneMode.Additive);

            PlayerInfo.piInstance.currentScene = areaName;

            player = other.GetComponent<PlayerController>();
        }

        if (other.tag == "NPC")
        {
            Follower.fiInstance.currentScene = areaName;
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
