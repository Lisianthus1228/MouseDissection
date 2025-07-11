using System;
using CTL_Intern;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject nameBox;
    public TMP_Text nameBoxText;
    public TMP_Text infoBoxText;
    
    [Header("Default Text")]
    public string defaultText = "Mouse Dissection Mockup";

    private Image nameBoxImage;
    private static UIManager _instance; // We are going to treat this as a singleton so that there only exist ONE instance of this class!

    /**
     * This should simplify the code across any interactables that requires to display text in the User Interfacaes through a singleton 
     */
    #region Unity Methods

    // --- Singleton and Initialisation ---
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {

        if (nameBox != null)
        {
            nameBoxImage = nameBox.GetComponent<Image>();
            nameBoxImage.enabled = false;
        }
        
        if (nameBoxText != null)
        {
            nameBoxText.text = "";
        }

        if (infoBoxText != null)
        {
            infoBoxText.text = defaultText;
        }
    }

    #endregion
    
    #region Public Calling Methods
    
    // Passes a string into the info box when called and provided with a string
    public static void SetNameBox(String text)
    {
        if (_instance == null || string.IsNullOrEmpty(text)) return;

        _instance.nameBoxText.text = text;
        _instance.nameBoxImage.enabled = true;
    }
    
    // Removes the name box when called
    public static void ClearInformations()
    {
        if (_instance == null) return;
        
        _instance.nameBoxText.text = "";
        _instance.nameBoxImage.enabled = false;
        _instance.infoBoxText.text = _instance.defaultText;
    }
    
    // Passes string to set the Title
    public static void SetInfoBox(String text)
    {
        if (_instance == null) return;

        _instance.infoBoxText.text = string.IsNullOrEmpty(text) ? _instance.defaultText : text;
    }

    // Used for filling the textbox and title for an Organ
    public static void SetOrganDetails(InspectableData inspectable)
    {
        if (_instance == null) return;
        SetNameBox(inspectable.name);
        SetInfoBox(inspectable.description);
    }

    public static void SetToolDetails(InspectableData inspectable)
    {
        if (_instance == null) return;
        SetNameBox(inspectable.name + " (Click to use)");
    }
    #endregion
}


