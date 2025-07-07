using UnityEngine;
using UnityEngine.UI;

public class Bone : MonoBehaviour
{
    // Skeletal View
    public Material ClearMaterial;
    public Material RegMaterial;
    public Material TransMaterial;

    public void ToggleVisiblity()
    {
        this.GetComponent<MeshRenderer>().material = RegMaterial;
        this.GetComponent<Collider>().enabled = true;

        GameObject.Find("Uncut").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject.Find("Uncut").GetComponent<Collider>().enabled = false;

        GameObject.Find("VisibilitySlider").GetComponent<Slider>().value = 1;
    }
}
