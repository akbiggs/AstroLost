using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSelectedComputer
{
    private GameObject selectable;
    private GameObject rayEmitter;

    public IsSelectedComputer(GameObject selectable, GameObject rayEmitter) {
        this.selectable = selectable;
        this.rayEmitter = rayEmitter;
    }

    public bool isHighlighted() {
        Ray ray = new Ray(rayEmitter.transform.position, rayEmitter.transform.rotation * Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 100);

        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, 100);

        foreach (RaycastHit hit in hits) {
          if (hit.collider.gameObject == selectable) {
              return true;
          }
        }
        return false;
    }
}
