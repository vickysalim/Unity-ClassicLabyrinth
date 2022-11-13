using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] PhoneGravity ball;
    private void OnTriggerEnter(Collider other)
    {
        ball.IsEnteringHole = true;
    }
}
