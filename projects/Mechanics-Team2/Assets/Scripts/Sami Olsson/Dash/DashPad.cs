using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPad : MonoBehaviour
{
    private PlayerControllerEK _playerController;
    
    private float currentMoveSpeed;
    
    
  
    void Start()
    {
        _playerController = gameObject.GetComponent<PlayerControllerEK>();
        currentMoveSpeed = _playerController.moveSpeed;
    }

  
    
   private void OnCollisionEnter(Collision hit)
    {

        switch (hit.gameObject.tag)
        {
            case "DashBoost":
                _playerController.moveSpeed = 20f;
                break;
           case "Ground":
               _playerController.moveSpeed = currentMoveSpeed; 
                   break;
       }
        
    }

}
   
