using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InfoBoxHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject infoBox;
    public GameObject titleBox;
    GameObject infoBoxText;
    GameObject titleBoxText;
    TMP_Text tmp_info_text;
    TMP_Text tmp_title_text;
    Image infoBoxImage;

    void Start() {
        infoBoxImage = infoBox.GetComponent<Image>();
        infoBoxText = GameObject.Find("InfoText");
        titleBoxText = GameObject.Find("TitleText");
        tmp_info_text = infoBoxText.GetComponent<TMP_Text>();
        tmp_title_text = titleBoxText.GetComponent<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        infoBoxImage.enabled = true;
        switch (gameObject.name) {
            // UI TOGGLES
            case "SkinToggle":
                tmp_info_text.text = "Integumentary View";
                break;
            case "FleshToggle":
                tmp_info_text.text = "Organ View";
                break;
            case "BoneToggle":
                tmp_info_text.text = "Skeletal View";
                break;

            default:
                tmp_info_text.text = "NO TEXT PROVIDED";
                break;
        }
    }

    public void OnMouseEnter() {
        infoBoxImage.enabled = true;
        switch (gameObject.name) {
            // ORGANS & ANATOMY
            /*
            case "Heart":
                tmp_info_text.text = "Heart";
                break;
            case "Stomach":
                tmp_info_text.text = "Stomach";
                break;
            */
            case "Scissors":
                tmp_info_text.text = "Dissecting Scissors";
                break;
            case "Seeker_Wood":
            case "Seeker_Metal":
                tmp_info_text.text = "Seekers";
                break;
            case "Awls":
                tmp_info_text.text = "Awls";
                break;
            case "Forceps":
                tmp_info_text.text = "Forceps";
                break;

            default: // If no highlight text provided just hide the info box.
                infoBoxImage.enabled = false;
                tmp_info_text.text = "";
                break;
        }
    }

    public void OnMouseDown() {
        switch (gameObject.name) {
            // ORGANS & ANATOMY
            case "Heart":
                tmp_title_text.text = "Heart: Pumps blood to rest of circulatory system";
                return;
            case "Stomach":
                tmp_title_text.text = "Stomach: Digests food";
                return;
            case "Intestines":
                tmp_title_text.text = "Intestines: Site of nutrient and ion absorption";
                return;
        }
        tmp_title_text.text = "Mouse Dissection Mockup";
    }

    public void OnPointerExit(PointerEventData eventData) {
        infoBoxImage.enabled = false;
        tmp_info_text.text = "";
    }
    public void OnMouseExit() {
        infoBoxImage.enabled = false;
        tmp_info_text.text = "";
    }
}
