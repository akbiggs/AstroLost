using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    private Vector2 yAxisBounds = new Vector2(-90, 90);
    private Vector2 xAxisBounds = new Vector2(-50, 50);

    public float mouseToRotationScalingFactor = 0.1f;
    public bool invertMouseY = false;
    public bool invertMouseX = false;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseOffset = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        Vector2 inversionFactor = new Vector2(invertMouseX ? -1 : 1, invertMouseY ? -1 : 1);

        // mouse x = axis y & mouse y = axis x, so reverse the mouse offset vector

        Vector2 rotationStep = reverse(mouseOffset * inversionFactor) * mouseToRotationScalingFactor;

        Vector3 currentAngle = myTransform.rotation.eulerAngles;

        Vector3 proposedAngle = 
            new Vector3(
                computeNewAngle(currentAngle.x, rotationStep.x, xAxisBounds),
                computeNewAngle(currentAngle.y, rotationStep.y, yAxisBounds),
                0);
        
        myTransform.rotation = Quaternion.Euler(proposedAngle);
    }

    private static float computeNewAngle(float original, float increment, Vector2 bounds) {
      return Mathf.Clamp(normalizeTo180(original + increment), min(bounds), max(bounds));
    }

    /** convert a [0,360] angle to [-180,180] */
    private static float normalizeTo180(float angle) {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }

    private static float min(Vector2 vector) {
        return Mathf.Min(vector.x, vector.y);
    }

    private static float max(Vector2 vector) {
        return Mathf.Max(vector.x, vector.y);
    }

    private static Vector2 reverse(Vector2 vector) {
        return new Vector2(vector.y, vector.x);
    }
}
