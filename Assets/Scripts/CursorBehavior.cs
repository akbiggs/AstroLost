using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    private Vector2 xAxisBounds = new Vector2(-90, 90);
    private Vector2 yAxisBounds = new Vector2(-50, 50);
    private Vector2 angle = Vector2.zero;
    
    public float mouseToRotationScalingFactor = 0.1f;
    public bool invertMouseY = false;
    public bool invertMouseX = false;

    private Transform myTansform;

    // Start is called before the first frame update
    void Start()
    {
        myTansform = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseOffset =
            new Vector2(
                (invertMouseX ? -1 : 1) * Input.GetAxisRaw("Mouse X"), 
                (invertMouseY ? -1 : 1) * Input.GetAxisRaw("Mouse Y"));
        
        Vector2 rotationStep = mouseOffset * mouseToRotationScalingFactor;

        Vector2 proposedAngle = 
            new Vector2(
                Mathf.Clamp(angle.x + rotationStep.x, xAxisBounds.x, xAxisBounds.y),
                Mathf.Clamp(angle.y + rotationStep.y, yAxisBounds.x, yAxisBounds.y));
        
        angle = proposedAngle;

        myTansform.rotation =
            Quaternion.Euler(angle.y, angle.x, 0);
    }
}
