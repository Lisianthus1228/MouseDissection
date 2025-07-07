using System.Collections;
using TMPro;
using UnityEngine;


public class ControlOutline : MonoBehaviour
{

    private Outline outline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Outline component
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            Debug.LogError("Outline component not found on " + gameObject.name);
        }
        outline.enabled = false;
    }

    void OnMouseEnter()
    {
        if (outline != null)
        {
            Debug.Log(this);
            outline.enabled = true;
            //ShowFloatingText(objectName);
        }
    }

    void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        outline.enabled = true;
    }
}
