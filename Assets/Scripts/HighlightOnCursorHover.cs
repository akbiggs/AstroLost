using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnCursorHover : MonoBehaviour
{
    public GameObject baseSelectionOnOrientationOf;
    public Color highlightedColor;

    private Material myMaterial;
    private Color originalColor;
    private IsSelectedComputer isSelectedComputer;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        originalColor = myMaterial.color;
        isSelectedComputer = new IsSelectedComputer(gameObject, baseSelectionOnOrientationOf);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.color = isSelectedComputer.isHighlighted() ? highlightedColor : originalColor;
    }
}
