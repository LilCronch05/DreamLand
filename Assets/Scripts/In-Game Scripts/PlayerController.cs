using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float health;
    public int damage;
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float hInput, vInput, jumpInput;
    Vector3 movementDirection;
    Animator playerAnim;

    [SerializeField]
    public GameObject model;
    [SerializeField]
    Image fogPanel;
    [SerializeField]
    GameObject hintText;
    [SerializeField]
    bool fade, fadeOn;

    StatManager myStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = new StatManager();
        
        playerAnim = GetComponent<Animator>();
        health = myStats.m_Constitution * 10;
        damage = myStats.m_Strength + (myStats.m_Dexterity / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fade)
        {
            vInput = Input.GetAxis("Vertical");
            hInput = Input.GetAxis("Horizontal");               
        }
        else
        {
            vInput = 0;
            hInput = 0;
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

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.Translate(new Vector3(hInput * speed * Time.deltaTime, 0, vInput * speed * Time.deltaTime));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2.0f;
        }
        else
        {
            speed = 1.0f;
        }

        //Make player jump
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
            playerAnim.SetBool("isJumping", true);
        }
        else
        {
            playerAnim.SetBool("isJumping", false);
        }

        //Make character sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20.0f;
            playerAnim.SetBool("isSprinting", true);

        }
        else
        {
            speed = 10.0f;
            playerAnim.SetBool("isSprinting", false);
        }

        //ANIMATIONS
        //Walking Forwards
        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetBool("isMovingFWD", true);
        }
        else
        {
            playerAnim.SetBool("isMovingFWD", false);
        }
        //Walking Backwards
        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetBool("isMovingBWD", true);
        }
        else
        {
            playerAnim.SetBool("isMovingBWD", false);
        }
        //Strafing Left
        if (Input.GetKey(KeyCode.A))
        {
            playerAnim.SetBool("isMovingLFT", true);
        }
        else
        {
            playerAnim.SetBool("isMovingLFT", false);
        }
        //Strafing Right
        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("isMovingRGT", true);
        }
        else
        {
            playerAnim.SetBool("isMovingRGT", false);
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
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 35, 60);

        //Camera Rotation
        if (Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * 2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetMouseButtonDown(0))
        {
            collision.gameObject.GetComponent<EnemyAI>().health -= damage;
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
