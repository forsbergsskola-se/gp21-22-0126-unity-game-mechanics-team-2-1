using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPad : MonoBehaviour
{
    private PlayerControllerSami _playerControllerSami;
    private float currentMoveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerSami = gameObject.GetComponent<PlayerControllerSami>();
        currentMoveSpeed = _playerControllerSami.moveSpeed;
    }

  
    
   private void OnCollisionEnter(Collision hit)
    {

        switch (hit.gameObject.tag)
        {
            case "DashBoost":
                _playerControllerSami.moveSpeed = 15f;
                break;
           case "Ground":
                _playerControllerSami.moveSpeed = currentMoveSpeed; 
                   break;
       }
        
    }

}
   
