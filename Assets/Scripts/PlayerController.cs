using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myBody;
 
    private string GROUND_TAG = "Ground";

    // Movement
    [SerializeField]
    private float moveSpeed = 10f;
    private float movementX;
  
    // Jump
    [SerializeField]
    private float jumpForce = 9f;
    [SerializeField]
    private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        myBody.velocity = new Vector3(movementX * moveSpeed, myBody.velocity.y, 0);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.velocity = new Vector3(myBody.velocity.x, jumpForce, myBody.velocity.z);
            isGrounded = false;
        }

        // Longer button press for higher jump
        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Quick button press for a lower jump
        else if (myBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            myBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checking for ground collision to allow jumping
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}
