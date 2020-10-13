using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float y_Restriction = 20f;
    [SerializeField] float x_Restriction = 20f;
    public float vacummSpeed = 1f;

    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position; // Stores the position of the GameObject when the game starts
    }

    public void Move(float movementFactor, Vector3 movementDirection) // Called in mouse input
    {
        ProcessHorizontalMovement(movementFactor, movementDirection);
        ProcessVerticalMovement(movementFactor, movementDirection);
    }

   

    private void ProcessHorizontalMovement(float movementFactor, Vector3 movementDirection)
    {
        float xOffset = movementFactor * movementDirection.x * Time.deltaTime;
        float raw_X_Pos = transform.position.x + xOffset;
        float clamped_X_Pos = Mathf.Clamp(raw_X_Pos, -x_Restriction + startingPos.x, x_Restriction + startingPos.x);

        transform.position = new Vector3(clamped_X_Pos, transform.position.y, transform.position.z);
    }
    private void ProcessVerticalMovement(float movementFactor, Vector3 movementDirection)
    {
        float yOffset = movementFactor * movementDirection.z * Time.deltaTime;
        float raw_Y_Pos = transform.position.z + yOffset;
        float clamped_Y_Pos = Mathf.Clamp(raw_Y_Pos, -y_Restriction + startingPos.z, y_Restriction + startingPos.z);

        transform.position = new Vector3(transform.position.x, transform.position.y, clamped_Y_Pos);
    }

    public float ProcessMovementFactor(float first, float second)
    {
        float movementFactorRaw = first - second;
        float movementFactorClamped = Mathf.Clamp(movementFactorRaw, Mathf.Epsilon, vacummSpeed);
        return movementFactorClamped;
    }
}
