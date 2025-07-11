using UnityEngine;
using CTL_Intern; 

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    [Tooltip("The ScriptableObject that holds the information for this item.")]
    public InspectableData inspectableData;
    
    [Header("Outline Settings")]
    [Tooltip("The Outline component attached to this GameObject.")]
    [SerializeField] protected Outline outline;
    [Tooltip("The color of the outline when the mouse hovers over the object.")]
    public Color outlineColor =  Color.cyan;
    [Tooltip("The width of the outline when the mouse hovers over the object.")]
    public float outlineWidth = 8.5f;
    
    // We use 'virtual' so child classes can override this if they need to.
    
    protected virtual void Awake()
    {
        // Getting the Outline component and setting its default parameters.
        outline = GetComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineWidth = outlineWidth;
        outline.enabled = false; // The outline is initially disabled.
    }


    // Called when the mouse pointer enters the collider of this object.
    protected virtual void OnMouseEnter()
    {
        if (outline == null) return;
        
        outline.enabled = true;
        
        // Call the abstract method to display this object's specific information.
        SetInformation();
    }


    // Called when the mouse pointer exits the collider of this object.
    protected virtual void OnMouseExit()
    {
        if (outline == null) return;
        
        // Disable the outline.
        outline.enabled = false;
        
        // Call the abstract method to clear the information from the UI.
        ClearInformation();
    }

    // Tells the UIManager to clear information.
    protected virtual void ClearInformation()
    {
        UIManager.ClearInformations();
    }
    
    // Responsible for telling the UIManager to display information, must be implemented by its children.
    protected abstract void SetInformation();
    
    
}
