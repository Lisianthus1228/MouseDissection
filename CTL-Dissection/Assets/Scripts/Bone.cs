using UnityEngine;

public class Bone : MonoBehaviour
{
    public Material ClearMaterial;
    public Material RegMaterial;
    public Material TransMaterial;

    public void ToggleVisiblity()
    {
        this.GetComponent<MeshRenderer>().material = RegMaterial;
        GameObject.Find("Skin").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject[] organs = GameObject.FindGameObjectsWithTag("Organs");
        foreach (GameObject organ in organs)
        {
            organ.GetComponent<MeshRenderer>().material = TransMaterial;
        }
    }
}
