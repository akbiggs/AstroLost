using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float movementForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isLeftPressed = Input.GetKey("left");
        bool isRightPressed = Input.GetKey("right");

        Vector3 force = new Vector3((isLeftPressed ? -1 : 0) + (isRightPressed ? 1 : 0), 0, 0) * movementForce;

        myRigidbody.AddRelativeForce(force, ForceMode.Force);
    }
}
