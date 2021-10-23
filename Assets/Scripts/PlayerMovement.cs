using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator playerAnimator;

    public float speed;

    public bool key1;
    public bool key2;
    public bool key3;



    Quaternion playerRotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start(){   
        speed=2;

        //set default that player starts with no keys obtained
        key1=false;
        key2=false;
        key3=false;

        //get components
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

        if(Time.timeScale==1f){

        
        //get input for both directions
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        //check for horizontal input, approximate 0
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        if(!hasHorizontalInput) horizontal=0f;
        if(!hasVerticalInput) vertical=0f;
        //if player walked, need to enable for animator
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnimator.SetBool("IsWalking", isWalking);


        //depending on input change players position and or rotation
        if (vertical > 0){
             transform.position += transform.forward * Time.deltaTime *speed;
         }
         if (vertical < 0){
             transform.position -= transform.forward * Time.deltaTime *speed;
         }
         if(horizontal > 0){
             transform.Rotate(0, 0.5f, 0, Space.Self);
         }
         if (horizontal < 0) {
             transform.Rotate(0, -0.5f, 0, Space.Self);
         }

        vertical=0;
        horizontal=0;
    }
    }

    //method to detect collisions
     private void OnCollisionEnter(Collision other) {

         //check for the 3 different keys
         if(other.gameObject.tag=="key1"){
             this.key1=true;    
             Destroy(other.gameObject);
         }
         //check for the 3 different keys
         if(other.gameObject.tag=="key2"){
             this.key2=true;    
             Destroy(other.gameObject);
         }

        //check for the 3 different keys
         if(other.gameObject.tag=="key3"){
             this.key3=true;    
             Destroy(other.gameObject);
         }

        //check if collide with door and if key was obtaineds
         if(other.gameObject.tag=="door1" && key1){
             Destroy(other.gameObject);
         }

        //check if collide with door and if key was obtaineds
         if(other.gameObject.tag=="door2" && key2){
             Destroy(other.gameObject);
         }

        //check if collide with door and if key was obtaineds
         if(other.gameObject.tag=="door3" && key3){
             Destroy(other.gameObject);
             GlobalScore.didWin=true; //ends game once door 3 is opened
         }
    }

}
