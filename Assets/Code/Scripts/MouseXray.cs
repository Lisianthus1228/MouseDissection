using UnityEngine;
using UnityEngine.UI;

public class MouseXray : MonoBehaviour
{
    public Material SkinMaterial;
    public Material ClearMaterial;

    public void ToggleVisiblity(System.Single visibility) {
        GameObject.Find("Uncut").GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, Mathf.Max(1-visibility, 0));
        GameObject.Find("Open").GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, Mathf.Max(1 - visibility, 0));
    }
}
