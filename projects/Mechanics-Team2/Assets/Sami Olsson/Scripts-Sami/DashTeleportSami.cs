using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashTeleportSami : MonoBehaviour
{
    private Rigidbody rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                direction = 1;
            } else if (Input.GetMouseButtonDown(2))
            {
                direction = 2;
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                }

                if (direction == 1)
                {
                    rb.velocity = Vector3.left * dashSpeed;
                } else if (direction == 2)
                {
                    rb.velocity = Vector3.right * dashSpeed;
                }else if (direction == 3)
                {
                    rb.velocity = Vector3.up * dashSpeed;
                }else if (direction == 4)
                {
                    rb.velocity = Vector3.down * dashSpeed;
                }
            }
            
        }
    }
}
