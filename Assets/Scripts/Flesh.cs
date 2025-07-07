using UnityEngine;
using UnityEngine.UI;

public class Flesh : MonoBehaviour
{
    // Organ View
    public Material ClearMaterial;
    public Material RegMaterial;
    public Material TransMaterial;

    public void ToggleVisiblity()
    {
        GameObject.Find("Uncut").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject.Find("Uncut").GetComponent<Collider>().enabled = false;

        GameObject.Find("Bone").GetComponent<MeshRenderer>().material = TransMaterial;
        GameObject.Find("Bone").GetComponent<Collider>().enabled = false;

        GameObject.Find("VisibilitySlider").GetComponent<Slider>().value = 1;
    }
}
