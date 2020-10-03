using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    private Color basicColor = new Color32(4, 89, 128, 255);
    private Color hoverColor = new Color32(119, 212, 253, 255);
    private Renderer renderer;
 
    void Start() {
        renderer = GetComponent<Renderer>();
        renderer.material.color = basicColor;
    }

    void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        renderer.material.color = basicColor;
    }
}
