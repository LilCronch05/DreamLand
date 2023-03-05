using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaLoad : MonoBehaviour
{
    [SerializeField]
    Transform entrance;
    [SerializeField]
    Transform exit;
    [SerializeField]
    string areaName;
    bool transition = false;

    // Update is called once per frame
    private void Update()
    {
        if (transition /*&& !player.Fading()*/)
        {
            SceneManager.LoadScene(areaName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Field1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInfo.piInstance.spawnLocation = exit.position;
            PlayerInfo.piInstance.currentScene = areaName;

            //player.Fade(true);
            transition = true;
        }
    }
}
