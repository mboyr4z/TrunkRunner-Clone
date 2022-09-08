using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoSingleton<MovementController>
{


    [SerializeField] private float speed;

    [SerializeField] private float horizontalMovementSensitivity;

    [SerializeField] private Vector2 horizontalClamp;


    private Rigidbody rb;

    private Vector2 firstMousePos;

    private Vector2 lastMousePos;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        transform.XClamp(horizontalClamp.x, horizontalClamp.y);

        if (GameStates.InRun.IsActive())      // isRun is active
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                if(firstMousePos != Vector2.zero)
                {
                    lastMousePos = Input.mousePosition;
                    MoveHorizontal((lastMousePos - firstMousePos).x);
                }
            }

            if (Input.GetMouseButtonUp(0))
                rb.velocity = Vector3.zero;

            firstMousePos = Vector2.Lerp(firstMousePos, lastMousePos, Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (GameStates.InRun.IsActive())
            MoveForward();

    }


    private void MoveForward()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, speed);
    }

    private void MoveHorizontal(float distanceMousePoses)
    {
        rb.velocity = new Vector3(distanceMousePoses * Time.fixedDeltaTime * horizontalMovementSensitivity, 0, rb.velocity.z);
    }
}
