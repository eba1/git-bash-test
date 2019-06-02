using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float inputDelay = 0.1f;

    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRoation;
    Rigidbody rBody;
    float forwardInput, turnInput;
    public Quaternion TargetRotation
    {
        get { return targetRoation; }

    }

    void Start()
    {
        targetRoation = transform.rotation;
        rBody = GetComponent<Rigidbody>();

    }
    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }
    void Update()
    {
        GetInput();
        Turn();

    }
    void FixedUpdate()
    {
        Run();
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
        {
            rBody.velocity = Vector3.zero;
        }
    }
    void Turn()
    {

        targetRoation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRoation;


    }
}
