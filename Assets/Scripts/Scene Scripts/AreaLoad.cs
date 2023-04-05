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

    // Update is called once per frame
    private void Update()
    {
        PlayerController.Destination.transform.position = exit.position;

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
            PlayerInfo.piInstance.currentScene = areaName;

            player = other.GetComponent<PlayerController>();
            player.Fade(true);
            transition = true;
        }
    }
}
