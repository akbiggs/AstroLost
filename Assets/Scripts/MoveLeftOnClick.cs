using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftOnClick : MonoBehaviour
{
    public GameObject baseSelectionOnOrientationOf;
    public GameObject applyForceTo;
    public float force;
    private IsSelectedComputer isSelectedComputer;
    private Rigidbody rigidbodyToApplyForceTo;

    // Start is called before the first frame update
    void Start()
    {
        isSelectedComputer = new IsSelectedComputer(gameObject, baseSelectionOnOrientationOf);
        rigidbodyToApplyForceTo = applyForceTo.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && isSelectedComputer.isHighlighted()) {
            rigidbodyToApplyForceTo.AddRelativeForce(Vector3.left * force, ForceMode.Force);
        }
    }
}
