using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float LANE_DISTANCE = 3.0f;
    private float jumpForce = 4.0f;
    private float gravity = 12.0f;

    private float verticalVelocity;
    private float speed = 7.0f;
    private CharacterController controller;
    private int desiredLane = 1; //0 = left, 1 = middle, 2 = right

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        //move left
        MoveLane(false);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        //move right
        MoveLane(true);

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0) 
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        //Move Vector 
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void MoveLane(bool goingRight)
    {
        //left
        if (!goingRight) {
            desiredLane--;
            if (desiredLane == -1) 
            desiredLane = 0;
        }
        //right
        else 
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
    }
}
