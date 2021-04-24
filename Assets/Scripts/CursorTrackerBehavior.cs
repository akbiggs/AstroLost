using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Track the rotation of another game object and ease this object's rotation to match. */
public class CursorTrackerBehavior : MonoBehaviour
{
    private Transform myTransform;
    private Transform trackedTransform;

    public GameObject trackedObject;

    public float easing = 0.5f;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        trackedTransform = trackedObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector3 targetRotation = normalizeTo180(trackedTransform.rotation.eulerAngles);
        Vector3 currentRotation = normalizeTo180(myTransform.rotation.eulerAngles);

        Vector3 rotationDelta = targetRotation - currentRotation;

        Vector3 proposedRotationDelta = (rotationDelta / (easing / deltaTime));

        Vector3 proposedRotation = currentRotation + proposedRotationDelta;
     
        myTransform.rotation = Quaternion.Euler(proposedRotation);

        myTransform.localPosition = trackedTransform.localPosition;
    }

    private static Vector3 normalizeTo180(Vector3 vector) {
        return new Vector3(normalizeTo180(vector.x), normalizeTo180(vector.y), normalizeTo180(vector.z));
    }

    /** convert a [0,360] angle to [-180,180] */
    private static float normalizeTo180(float angle) {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }

}