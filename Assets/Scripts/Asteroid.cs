using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Transform transform;

    private Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();

        rigidbody.angularVelocity = new Vector3(Random.value, Random.value, Random.value);

        Debug.Log(rigidbody.angularVelocity);

        float scale = Random.value;
        transform.localScale = Vector3.one + new Vector3(scale, scale, scale) * 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
