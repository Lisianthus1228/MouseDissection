using UnityEngine;

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

        GameObject.Find("Skin").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject.Find("Skin").GetComponent<Collider>().enabled = false;

        GameObject[] organs = GameObject.FindGameObjectsWithTag("Organs");
        foreach (GameObject organ in organs)
        {
            organ.GetComponent<MeshRenderer>().material = TransMaterial;
            organ.GetComponent<Collider>().enabled = false;
        }
    }
}
