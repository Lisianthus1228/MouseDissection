using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    // Integumentary View
    public Material RegMaterial;
    public Material FleshMaterial;
    public Material BoneMaterial;

    public void ToggleVisiblity() {
        this.GetComponent<MeshRenderer>().material = RegMaterial;
        this.GetComponent<Collider>().enabled = true;

        GameObject.Find("Bone").GetComponent<MeshRenderer>().material = BoneMaterial;
        GameObject.Find("Bone").GetComponent<Collider>().enabled = true;

        GameObject.Find("VisibilitySlider").GetComponent<Slider>().value = 0;
    }
}
