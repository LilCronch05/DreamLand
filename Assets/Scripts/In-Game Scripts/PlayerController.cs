using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float horizontalInput, forwardInput, jumpInput;
    Vector3 movementDirection;

    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxis("Jump");
        movementDirection = new Vector3(horizontalInput, 0, forwardInput);
        movementDirection.Normalize();

        // Move player forwards and backwards
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.Self);
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
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetMouseButtonDown(0))
        {
            Destroy(collision.gameObject);
        }

    }
    */
}
