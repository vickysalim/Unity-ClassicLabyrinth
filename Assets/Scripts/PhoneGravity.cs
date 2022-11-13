using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGravity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float gravityMagnitude;
    bool useGyro;
    Vector3 gravityDir;

    bool isEnteringHole = false;
    public bool IsEnteringHole { get => isEnteringHole; set => isEnteringHole = value; }

    void Start()
    {
        if(SystemInfo.supportsGyroscope)
        {
            useGyro = true;
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        var inputDir = useGyro ? Input.gyro.gravity : Input.acceleration;

        if (IsEnteringHole)
            return;

        gravityDir = new Vector3(
            inputDir.x,
            inputDir.z,
            inputDir.y
        );
    }

    void FixedUpdate()
    {
        rb.AddForce(gravityDir * gravityMagnitude, ForceMode.Acceleration);    
    }
}
