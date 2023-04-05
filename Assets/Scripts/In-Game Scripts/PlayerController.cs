using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float health;
    public int damage;
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnim;
    [SerializeField]
    public static GameObject Destination;
    
    [SerializeField]
    Image fogPanel;
    [SerializeField]
    GameObject hintText;
    [SerializeField]
    bool fade, fadeOn, collided;

    // Start is called before the first frame update
    void Start()
    {        
        playerAnim = GetComponent<Animator>();
        health = GameManager.gmInstance.gameData.charCON * 10;
        damage = GameManager.gmInstance.gameData.charSTR + (GameManager.gmInstance.gameData.charDEX / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponent<EnemyAI>().health -= damage;
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
                    Destination.transform.position = hit.point;
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
        // //Walking Backwards
        // if (player.velocity.x < 0)
        // {
        //     playerAnim.SetBool("isMovingBWD", true);
        // }
        // else
        // {
        //     playerAnim.SetBool("isMovingBWD", false);
        // }
        // //Strafing Left
        // if (player.velocity.z > 0)
        // {
        //     playerAnim.SetBool("isMovingLFT", true);
        // }
        // else
        // {
        //     playerAnim.SetBool("isMovingLFT", false);
        // }
        // //Strafing Right
        // if (player.velocity.z < 0)
        // {
        //     playerAnim.SetBool("isMovingRGT", true);
        // }
        // else
        // {
        //     playerAnim.SetBool("isMovingRGT", false);
        // }
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
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 60, 90);

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
            collided = true;
            Debug.Log("collided");
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
