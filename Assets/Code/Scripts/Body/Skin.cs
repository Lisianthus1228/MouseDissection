using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public GameObject mouse_skin;
    public GameObject mouse_cut_skin;

    public void CutOpen() {
        mouse_skin.GetComponent<MeshRenderer>().enabled = false;
        mouse_skin.GetComponent<BoxCollider>().enabled = false;

        mouse_cut_skin.GetComponent<MeshRenderer>().enabled = true;
        mouse_cut_skin.GetComponent<MeshRenderer>().material.color = mouse_skin.GetComponent<MeshRenderer>().material.color;
    }
}
