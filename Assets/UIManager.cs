using System;
using CTL_Intern;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject infoBox;
    public TMP_Text infoBoxText;
    public TMP_Text titleBoxText;
    
    [Header("Default Text")]
    public string defaultText = "Mouse Dissection Mockup";

    private Image infoBoxImage;
    private static UIManager instance; // We are going to treat this as a singleton so that there only exist ONE instance of this class!

    /**
     * This should simplify the code across any interactables that requires to display text in the User Interfacaes through a singleton 
     */
    #region Unity Methods

    // --- Singleton and Initialisation ---
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {

        if (infoBox != null)
        {
            infoBoxImage = infoBox.GetComponent<Image>();
            infoBoxImage.enabled = false;
        }
        
        if (infoBoxText != null)
        {
            infoBoxText.text = "";
        }

        if (titleBoxText != null)
        {
            titleBoxText.text = defaultText;
        }
    }

    #endregion
    
    #region Public Calling Methods
    
    // Passes a string into the info box when called and provided with a string
    public static void SetInfoText(InspectableData inspectable)
    {
        if (instance == null || string.IsNullOrEmpty(inspectable.description)) return;

        instance.infoBoxText.text = inspectable.description;
        instance.infoBoxImage.enabled = true;
    }
    
    // Removes the info box when called
    public static void HideInfoBox()
    {
        if (instance == null) return;
        
        instance.infoBoxText.text = "";
        instance.infoBoxImage.enabled = false;
    }
    
    // Passes string to set the Title
    public static void SetTitle(InspectableData inspectable)
    {
        if (instance == null) return;

        instance.titleBoxText.text = string.IsNullOrEmpty(inspectable.name) ? instance.defaultText : inspectable.name;
    }
    #endregion
}


