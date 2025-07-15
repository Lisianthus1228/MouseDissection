using UnityEngine;

namespace CTL_Intern
{
    [CreateAssetMenu(fileName = "New Outline Data", menuName = "Internship/Outline Data")]
    public class OutlineData : ScriptableObject
    {
        [Tooltip("The colour of the outline.")]
        public Color colour;

        [Tooltip("The width of the outline.")]
        public float width;
    }
}
