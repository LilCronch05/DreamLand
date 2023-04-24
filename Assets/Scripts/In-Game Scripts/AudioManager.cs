using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_BGM;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Inn1")
        {
            m_BGM.Pause();
        }
        else if (SceneManager.GetActiveScene().name != "Inn1")
        {
            m_BGM.UnPause();
        }
    }
}
