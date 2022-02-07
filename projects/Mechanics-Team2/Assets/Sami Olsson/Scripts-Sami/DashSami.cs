using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSami : MonoBehaviour
{
   private PlayerControllerSami moveScript;

   public float dashSpeed;
   public float dashTime;

   private void Start()
   {
      moveScript = GetComponent<PlayerControllerSami>();
   }


   private void Update()
   {
      if (Input.GetMouseButton(0))
      {
         //StartCoroutine(Dash());
      }
   }



   //IEnumerator Dash()
  // {
     // float startTime = Time.time;

     // while (Time.time < startTime + dashTime)
     // {
         //moveScript.(moveScript.moveDir * dashSpeed + Time.deltaTime)
     // }
   //}
}
