using UnityEngine;

public class Flesh : MonoBehaviour
{
    // Organ View
    public Material ClearMaterial;
    public Material RegMaterial;
    public Material TransMaterial;

    public void ToggleVisiblity()
    {
        GameObject[] organs = GameObject.FindGameObjectsWithTag("Organs");
        foreach (GameObject organ in organs)
        {
            organ.GetComponent<MeshRenderer>().material = RegMaterial;
            organ.GetComponent<Collider>().enabled = true;
        }

        GameObject.Find("Skin").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject.Find("Skin").GetComponent<Collider>().enabled = false;

        GameObject.Find("Bone").GetComponent<MeshRenderer>().material = TransMaterial;
        GameObject.Find("Bone").GetComponent<Collider>().enabled = false;
    }
}
