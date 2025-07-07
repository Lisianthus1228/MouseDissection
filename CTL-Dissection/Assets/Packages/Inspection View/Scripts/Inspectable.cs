using UnityEngine;

namespace CTL_Intern
{
    public class Inspectable : MonoBehaviour
    {
        [Tooltip("The Scriptable Object asset that holds the data for this item.")]
        public InspectableData data;
    }
}
