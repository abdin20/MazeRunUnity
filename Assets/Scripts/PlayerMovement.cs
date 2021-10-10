using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator playerAnimator;

    public float turnSpeed;

    Quaternion playerRotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {   
        turnSpeed=20;
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input for both directions
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //get vector as result of input
        movement.Set(horizontal, 0f, vertical);

        //normalize vector so its always 1 magnitude
        movement.Normalize();

        //check for horizontal input, approximate 0
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        //if player walked, need to enable for animator
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnimator.SetBool("isWalking", isWalking);


        //vector in which direction object should rotate based on movement
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        playerRotation = Quaternion.LookRotation (desiredForward);

        playerRigidbody.MovePosition(transform.position+ movement*10);
    }


       void OnAnimatorMove ()
    {

        playerRigidbody.MovePosition (playerRigidbody.position + movement * playerAnimator.deltaPosition.magnitude);
        playerRigidbody.MoveRotation (playerRotation);

    }
}
