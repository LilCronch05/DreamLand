using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaManager : MonoBehaviour
{
    [SerializeField]
    Transform spawn;
    //RPGCharacterInputController player;
    bool transition = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawn.position;
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<>();
        //player.Fade(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transition /*&& !player.Fading()*/)
        {
            SceneManager.LoadScene("Field", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //player = other.GetComponent<>();
        //player.Fade(true);
        transition = true;
    }
}
