using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerControllerSami : MonoBehaviour
{
       public Rigidbody myRigidbody;
       public float moveSpeed = 5f;
       public float jumpForce = 500f;

       [SerializeField] private Transform groundCheck;
       [SerializeField] private LayerMask ground;
    

       private void Update()
       { 
           
           
           //Get move input
           //Preferably get input in Update()
           var moveInput = Input.GetAxis("Horizontal");
   
           //Set move velocity
           //Preferably interact with physics in FixedUpdate() 
           myRigidbody.velocity = new Vector3(moveInput * moveSpeed, myRigidbody.velocity.y, 0);
   
           //Get jump input
           //Preferably get input in Update()
           var jumpInput = Input.GetKeyDown(KeyCode.Space);
   
           //Apply jump force
           //Preferably interact with physics in FixedUpdate() 
           if (jumpInput && IsGrounded())
               myRigidbody.AddForce(Vector3.up * jumpForce);
           
       }

        
      
          
       bool IsGrounded()
       {
           return Physics.CheckSphere(groundCheck.position, .1f, ground);
       }

     
}
