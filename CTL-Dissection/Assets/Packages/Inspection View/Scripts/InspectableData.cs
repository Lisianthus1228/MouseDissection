using UnityEngine;

namespace CTL_Intern
{
    [CreateAssetMenu(fileName = "New Inspectable Data", menuName = "Inspection/Inspectable Item")]
    public class InspectableData : ScriptableObject
    {
        [Header("Inspection Details")]
        [Tooltip("The prefab to spawn in the inspection view.")]
        public GameObject inspectionPrefab;

        [Tooltip("The name of the item to display.")]
        public string name;

        [TextArea(3, 10)]
        [Tooltip("The description to display in the UI.")]
        public string description;
    }
}
