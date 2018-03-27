using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPadMover : MonoBehaviour
{

    public float speed;
    private Rigidbody ballRigidBody;
    SteamVR_TrackedObject controller;
    public GameObject plane; 


    void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidBody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //get which device this is
        var device = SteamVR_Controller.Input((int)controller.index);

        //if touching the touchpad, we'll move the ball
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var model = this.transform.Find("Model");

            //the location of trackpad in world space
            Transform trackpad = model.Find("trackpad").Find("attach");

            //the location of trackpad touched in worldspace
            Transform touch = model.Find("trackpad_touch").Find("attach");

            //compute difference in positions
            Vector3 movement = (touch.position) - (trackpad.position);

            //modify the vector to ignore up down component
            movement = new Vector3(movement.x, 0, movement.z);

            //to be avle to control velocity through speed variable
            movement.Normalize();

            //add a force to the ball
            this.ballRigidBody.AddForce(movement * speed);
        }
    }

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(plane.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
