using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody RB;

    void Awake() 
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RB.AddForce(Vector3.down * GameManager.Get().GravityScale);
    }
}
