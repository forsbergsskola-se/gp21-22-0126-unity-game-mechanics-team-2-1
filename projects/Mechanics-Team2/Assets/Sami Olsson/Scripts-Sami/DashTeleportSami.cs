using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashTeleportSami : MonoBehaviour
{
    
    [SerializeField] Rigidbody myRigidbody;
    
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private  float dashTimeCounter = 0f;
    [SerializeField] private float chargeTime = 1f;
    
    
    private bool canDash;
    private bool canWalk;
    
    private float dashCharge;

    private void Start()
    {
        canDash = true;
        canWalk = true;
    }

    void Update()
    {
     
        if (Input.GetKey(KeyCode.Q))
        {
            dashCharge += Time.deltaTime / chargeTime;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            dashCharge = Mathf.Clamp(dashCharge, 0f, 1f);
            
            StartCoroutine(dash(dashCharge));
            Debug.Log(dashCharge);
            dashCharge = 0f;
        }
    }
    
    
    private IEnumerator dash(float input)
    {
        while (dashTimeCounter <= dashTime )
        {
            myRigidbody.velocity = new Vector3(dashSpeed * input, myRigidbody.velocity.y);
            dashTimeCounter += Time.deltaTime;
            yield return null;
        }
        myRigidbody.velocity = Vector3.zero;
    
        canDash = true;
        dashTimeCounter = 0f;
        Debug.Log(canDash);
        yield return null;
    }
}
