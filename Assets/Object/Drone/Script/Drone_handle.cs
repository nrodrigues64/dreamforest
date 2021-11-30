using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Drone_handle : MonoBehaviour
{
    public float speed;
    private float translationx;
    private float translationz;
    private float thrusty;

    public bool IsOn = true;

    private float speedxy = 3f;
    private float speedz =6f;

    private Rigidbody rigidbodyComponent;

    public bool IsLeader = false;
    public bool IsAutonomous = false;

    public float motor_Forward_Right = 0.0f;
    public float motor_Forward_Left = 0.0f;
    public float motor_Backward_Right = 0.0f;
    public float motor_Backward_Left = 0.0f;


    private float max_angle = 20f;
    private Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCommand();
    }

    void FixedUpdate()
    {
        Movement_Update();
        Wheel_Update();
        Rotation_Update();


    }

    void GetCommand()
    {


        if (Input.GetKeyDown(KeyCode.O))
        {
            if (IsOn == false)
            {
                IsOn = true;
            }
            else
            {
                IsOn = false;
            }
        }

        translationx = Input.GetAxis("Vertical");
        translationz = -Input.GetAxis("Horizontal");
        thrusty = Input.GetAxis("VerticalZ");
        Debug.Log("thrust = "+ thrusty);
/*        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpThrust = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpThrust = false;
        }*/


    }

    void Wheel_Update()
    {
        if (IsOn == true)
        {
            motor_Forward_Right = 100;
            motor_Forward_Left = 100;
            motor_Backward_Right = 100;
            motor_Backward_Left = 100;

        }

        else
        {
            motor_Forward_Right = 0;
            motor_Forward_Left = 0;
            motor_Backward_Right = 0;
            motor_Backward_Left = 0;
        }

    }







    void Movement_Update()
    {


        /*   Vector3 movement = new Vector3(translationx, rigidbodyComponent.velocity.y, translationz);*/
        /* rigidbodyComponent.AddForce(movement);*/


        /*   rigidbodyComponent.velocity.y */

        /*Rigibody way*/
        if (IsOn)
            
        {
            Debug.Log("true isOn");
            rigidbodyComponent.velocity = new Vector3(translationx * speedxy, thrusty * speedz, translationz * speedxy) ; 
        }
        else
        { rigidbodyComponent.velocity = new Vector3(translationx * speedxy, rigidbodyComponent.velocity.y, translationz * speedxy); }





    }






    void Rotation_Update()
    { 
    /*faire pencher le drone quand il avance
   x et z sont inversé car si il se déplace en Z il se penche en x et inversement,
  de plus nous allons calculer
   */
        Quaternion target = Quaternion.Euler(translationz*max_angle, 0.0f,  -translationx*max_angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 5f);


    }



}
