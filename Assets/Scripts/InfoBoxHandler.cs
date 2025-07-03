using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InfoBoxHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject infoBox;
    GameObject infoBoxText;
    TMP_Text tmp_text;
    Image infoBoxImage;

    void Start() {
        infoBoxImage = infoBox.GetComponent<Image>();
        infoBoxText = GameObject.Find("InfoText");
        tmp_text = infoBoxText.GetComponent<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        infoBoxImage.enabled = true;
        switch (gameObject.name) {
            case "SkinToggle":
                tmp_text.text = "Integumentary View";
                break;
            case "FleshToggle":
                tmp_text.text = "Organ View";
                break;
            case "BoneToggle":
                tmp_text.text = "Skeletal View";
                break;
            default:
                tmp_text.text = "NO TEXT PROVIDED";
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        infoBoxImage.enabled = false;
        tmp_text.text = "";
    }
}
