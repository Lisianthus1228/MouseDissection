using UnityEngine;

public class Skin : MonoBehaviour
{
    public Material RegMaterial;
    public Material FleshMaterial;
    public Material BoneMaterial;

    public void ToggleVisiblity() {
        this.GetComponent<MeshRenderer>().material = RegMaterial;
        GameObject[] organs = GameObject.FindGameObjectsWithTag("Organs");
        foreach (GameObject organ in organs) {
            organ.GetComponent<MeshRenderer>().material = FleshMaterial;
        }
        GameObject.Find("Bone").GetComponent<MeshRenderer>().material = BoneMaterial;
    }
}
