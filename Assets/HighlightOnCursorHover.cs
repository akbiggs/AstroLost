using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnCursorHover : MonoBehaviour
{
    public GameObject rayEmitter;

    private Material myMaterial;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        originalColor = myMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.color = isHighlighted() ? Color.green : originalColor;
    }

    private bool isHighlighted() {
        Ray ray = new Ray(rayEmitter.transform.position, rayEmitter.transform.rotation * Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 100);

        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, 100);

        foreach (RaycastHit hit in hits) {
          if (hit.collider.gameObject == gameObject) {
              return true;
          }
        }
        return false;
    }
}
