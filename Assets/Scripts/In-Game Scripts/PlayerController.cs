using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float m_MaxHealth, health, m_MaxExperience, experience;
    public int level;
    public int damage;
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnim;
    public GameObject enemy;
    
    [SerializeField]
    private Image m_HealthBar, m_ExperienceBar;
    [SerializeField]
    Image fogPanel;
    [SerializeField]
    GameObject hintText;
    [SerializeField]
    bool fade, fadeOn, colliding;

    // Start is called before the first frame update
    void Start()
    {        
        playerAnim = GetComponent<Animator>();
        level = GameManager.gmInstance.gameData.charLevel;
        m_MaxHealth = GameManager.gmInstance.gameData.charCON * 10;
        health = GameManager.gmInstance.gameData.charCON * 10;
        m_MaxExperience = 100;
        experience = 0;
        damage = GameManager.gmInstance.gameData.charSTR + (GameManager.gmInstance.gameData.charDEX / 2);
        fade = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_HealthBar.gameObject.GetComponent<RectTransform>().localScale = new Vector3(health / m_MaxHealth, 1.5f, 1.5f);
        m_ExperienceBar.gameObject.GetComponent<RectTransform>().localScale = new Vector3(experience / m_MaxExperience, 1.5f, 1.5f);

        if(experience >= m_MaxExperience)
        {
            level++;
            experience = 0;

            //Increase stats
            m_MaxExperience += 100;
            GetComponent<StatManager>().IncreaseStat("Level");
            GetComponent<StatManager>().IncreaseStat("CON");
            GetComponent<StatManager>().IncreaseStat("STR");
            GetComponent<StatManager>().IncreaseStat("DEX");
            GetComponent<StatManager>().IncreaseStat("INT");
            GetComponent<StatManager>().IncreaseStat("WIS");
        }
        //Update personal stats
        damage = GameManager.gmInstance.gameData.charSTR + (GameManager.gmInstance.gameData.charDEX / 2);
        m_MaxHealth = GameManager.gmInstance.gameData.charCON * 10;

        if (colliding)
        {
            // Find the enemy that the player is colliding with
            if (Input.GetMouseButtonDown(0))
            {
                enemy.GetComponent<EnemyAI>().health -= damage;
                Debug.Log("Player attacked enemy");
            }
        }

        if (!fade)
        {
            // The character moves where the mouse clicks
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    player.SetDestination(hit.point);
                }
            }
                    
        }
        else
        {
            if (fadeOn && fogPanel.color.a < 1)
            {
                //Debug.Log(fogPanel.color.a);
                fogPanel.color = new Color(fogPanel.color.r, fogPanel.color.g, fogPanel.color.b, fogPanel.color.a + Time.deltaTime);

                hintText.SetActive(true);
            }
            else if (!fadeOn && fogPanel.color.a > 0)
            {
                fogPanel.color = new Color(fogPanel.color.r, fogPanel.color.g, fogPanel.color.b, fogPanel.color.a - Time.deltaTime);
            }
            else
            {
                fade = false;
                hintText.SetActive(false);
            }
            
        }

        //Make character stop moving
        if(Input.GetKey(KeyCode.LeftShift))
        {
            player.speed = 0;
            playerAnim.SetBool("isMovingFWD", false);
            playerAnim.SetBool("isMovingBWD", false);
            playerAnim.SetBool("isMovingLFT", false);
            playerAnim.SetBool("isMovingRGT", false);
        }
        else
        {
            player.speed = 5;
        }

        //ANIMATIONS
        //Walking Forwards
        if (player.velocity.x != 0)
        {
            playerAnim.SetBool("isMovingFWD", true);
        }
        else
        {
            playerAnim.SetBool("isMovingFWD", false);
        }

        //Attacking
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetBool("isAttacking", true);   
        }
        else
        {
            playerAnim.SetBool("isAttacking", false);
        }

        //CAMERA
        //Camera Zoom with Mouse Wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView -= 5;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.fieldOfView += 5;
        }
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 60, 75);

        //Camera Rotation
        if (Input.GetKey(KeyCode.Mouse2))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * 2);
        }

        // Camera follows player
        cam.transform.position = new Vector3(transform.position.x + 3.0f, transform.position.y + 7.3f, transform.position.z - 3.0f);
        cam.transform.LookAt(transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            colliding = true;
            enemy = other.gameObject.transform.parent.gameObject;
            Debug.Log("colliding");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            colliding = false;
            Debug.Log("not colliding");
        }
    }

    public void Fade(bool on)
    {
        fade = true;
        fadeOn = on;
    }

    public bool Fading()
    {
        return fade;
    }
}
