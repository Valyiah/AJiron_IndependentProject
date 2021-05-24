using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Used script from a Brackeys video but adjusted to use the Rigidbody instead
    // of a character controller alongside Cinemachine for the camera.
    // Link: https://www.youtube.com/watch?v=4HpC--2iowE
    // Jump is the same as the Lesson Unit 3 but with a different Ground detection, using Physics.CheckCapsule
    // With help using Omnirift's video on jump and ground detection
    // Link: https://www.youtube.com/watch?v=vdOFUFMiPDU

    public Rigidbody rb;
    public CapsuleCollider col;
    public Transform cam;
    private Animator animPlayer;
    public DepleteOxygen depleteOxygen;

    private AudioSource asPlayer;

    public LayerMask groundLayers;

    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float turnSmoothTime = 0.1f;
    public float jumpForce = 7.0f;

    float turnSmoothVelocity;
    public bool gameOver = false;
    public bool triggerEntered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        animPlayer = GetComponent<Animator>();
        depleteOxygen = GetComponent<DepleteOxygen>();
        asPlayer = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, Vertical).normalized;
        //Normalized to avoid accelerating if using two keys together
        //explained in Brackeys video

        if (direction.magnitude >= 0.1f && !gameOver)
        {
            animPlayer.SetBool("isWalking", true); //Walk animation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // Calculation so that player will move forward based on rotation and player will turn where camera faces
            // Angle in radians, convert to degrees, get angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // To smooth angles and make less snappy
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //The actual turn movement
            rb.MovePosition(transform.position + (moveDir.normalized * walkSpeed * Time.deltaTime));
            //Movement with WASD
            bool runPressed = Input.GetKey(KeyCode.LeftShift);

            if (runPressed && !gameOver)
            {
                rb.MovePosition(transform.position + (moveDir.normalized * runSpeed * Time.deltaTime));
                //Running Speed
                animPlayer.SetBool("isRunning", true); //Running Animation
            }
            if (!runPressed)
            {
                animPlayer.SetBool("isRunning", false); //Stop Running Animation
            }
        }

        else if (direction.magnitude <= 0.1f) //If not moving
        {
            animPlayer.SetBool("isWalking", false); //Stop Walk Animation
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Impulse adds amount of force once
            asPlayer.Play();
            //animPlayer.SetTrigger("Jump");
        }

        if (!IsGrounded())
        {
            animPlayer.SetBool("isWalking", false);
            animPlayer.SetBool("isRunning", false);
        }

        if (depleteOxygen.curOxygen <=0)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animPlayer.SetBool("isWalking", false);
            animPlayer.SetBool("isRunning", false);
            asPlayer.Pause();
            //Game Over Parameters
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eggship")
        {
            triggerEntered = true;
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Eggship")
        {
            triggerEntered = false;
            Debug.Log("Exited");
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
