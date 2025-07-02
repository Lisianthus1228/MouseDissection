using UnityEngine;

public class Skin : MonoBehaviour
{
    public Material ClearMaterial;
    public Material RegMaterial;
    bool visible = true;

    public void ToggleVisiblity() {
        if (visible) {
            this.GetComponent<MeshRenderer>().material = ClearMaterial;
        } else {
            this.GetComponent<MeshRenderer>().material = RegMaterial;
        }
        visible = !visible;
    }
}
