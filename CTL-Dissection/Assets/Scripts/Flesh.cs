using UnityEngine;

public class Flesh : MonoBehaviour
{
    public Material ClearMaterial;
    public Material RegMaterial;
    public Material TransMaterial;

    public void ToggleVisiblity()
    {
        GameObject[] organs = GameObject.FindGameObjectsWithTag("Organs");
        foreach (GameObject organ in organs)
        {
            organ.GetComponent<MeshRenderer>().material = RegMaterial;
        }
        GameObject.Find("Skin").GetComponent<MeshRenderer>().material = ClearMaterial;
        GameObject.Find("Bone").GetComponent<MeshRenderer>().material = TransMaterial;
    }
}
