using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Track the rotation of another game object and ease this object's rotation to match. */
public class CursorTrackerBehavior : MonoBehaviour
{
    private Transform myTransform;
    private Transform trackedTransform;

    public GameObject trackedObject;

    public float easing = 1;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        trackedTransform = trackedObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector3 targetOrientation = normalizeTo180(trackedTransform.rotation.eulerAngles);
        Vector3 currentOrientation = normalizeTo180(myTransform.rotation.eulerAngles);

        Vector3 orientationDelta = targetOrientation - currentOrientation;
        float orientationDeltaMag = orientationDelta.magnitude;
        float proposedDeltaMag = Mathf.Min(orientationDeltaMag, easing * deltaTime);
        float proposedDeltaMagScale = proposedDeltaMag < orientationDeltaMag ? proposedDeltaMag / orientationDeltaMag : 1;
        Vector3 proposedOrientation = proposedDeltaMagScale < 1 ? (currentOrientation + orientationDelta * proposedDeltaMagScale) : targetOrientation;

        myTransform.rotation = Quaternion.Euler(proposedOrientation);

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