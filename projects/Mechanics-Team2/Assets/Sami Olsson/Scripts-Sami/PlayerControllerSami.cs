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

       [Header("Dashing")]
       
       [SerializeField] private float dashingVelocity = 14f;
       [SerializeField] private float dashingTime = 0.5f;
       private Vector2 dashingDir;
       private bool isDashing;
       private bool canDash = true;
       
       
        



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

           //Get Move input for dash
           var dashInput = Input.GetButtonDown("Dash");

          //Dash mechanic 
           if (dashInput && canDash)
           {
               isDashing = true;
               canDash = false;
               dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
               if (dashingDir == Vector2.zero)
               {
                   dashingDir = new Vector2(transform.localScale.x, 0);
               }

               StartCoroutine(StopDashing());
           }

           if (isDashing)
           {
               myRigidbody.velocity = dashingDir.normalized * dashingVelocity;
               return;
           }

           if (IsGrounded())
           {
               canDash = true;
           }
       }


       private IEnumerator StopDashing()
       {
           yield return new WaitForSeconds(dashingTime);
           isDashing = false;
       }

       bool IsGrounded()
       {
           return Physics.CheckSphere(groundCheck.position, .1f, ground);
       }

     
}
