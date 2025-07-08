using TMPro;
using UnityEngine;

namespace CTL_Intern
{
    public class InspectSystem : MonoBehaviour
    {
        [Header("Setup")]
        [Tooltip("An empty GameObject that marks the position and initial rotation for spawning the object.")]
        public Transform spawnPoint;
        [Tooltip("TMP Object for the NAME of the Object")]
        public TMP_Text objectName;
        [Tooltip("TMP Object for the DESCRIPTION of the Object")]
        public TMP_Text objectDescription;

        [Header("Settings")]
        [Tooltip("How fast the object rotates with mouse movement.")]
        public float rotationSpeed = 100f;
        [Tooltip("The angle in degrees to rotate the object when using the manual rotation buttons.")]
        public float manualRotationAngle = 15f;

        private GameObject objectInstance;
        private Transform objectToInspect;
        private Vector3 prevMousePos;
        private Quaternion initialRotation; 
        
        #region Rotation Methods
        
        /// <summary>
        /// Rotates the object by a specific angle.
        /// </summary>
        /// <param name="rotationAngle">The Euler angle to rotate by.</param>
        public void RotateManually(Vector3 rotationAngle)
        {
            if (objectToInspect == null) return;

            // Create a quaternion from the specified Euler angles
            var rotation = Quaternion.Euler(rotationAngle);

            // Apply the rotation to the object's current rotation
            objectToInspect.rotation = rotation * objectToInspect.rotation;
        }
        
        /// <summary>
        /// Rotates the object upwards by the manualRotationAngle.
        /// </summary>
        public void RotateUp()
        {
            RotateManually(new Vector3(manualRotationAngle, 0, 0));
        }

        /// <summary>
        /// Rotates the object downwards by the manualRotationAngle.
        /// </summary>
        public void RotateDown()
        {
            RotateManually(new Vector3(-manualRotationAngle, 0, 0));
        }

        /// <summary>
        /// Rotates the object to the left by the manualRotationAngle.
        /// </summary>
        public void RotateLeft()
        {
            RotateManually(new Vector3(0, manualRotationAngle, 0));
        }

        /// <summary>
        /// Rotates the object to the right by the manualRotationAngle.
        /// </summary>
        public void RotateRight()
        {
            RotateManually(new Vector3(0, -manualRotationAngle, 0));
        }
        
        /// <summary>
        /// Resets the object to the original orientation.
        /// </summary>
        public void RotateReset()
        {
            if (objectToInspect == null) return;
            objectToInspect.rotation = initialRotation;
        }
        
        #endregion
        
        #region Inspector
        
        /// <summary>
        /// This method starts the Inspector View to interact with the provided InspectableData ScriptableObject. This
        /// will first destroy any exist object and clear the text box before populating with the provided object.
        /// </summary>
        /// <param name="inspectableData">The data it should display in the spector.</param>
        public void StartInspection(InspectableData inspectableData)
        {
            if (objectInstance != null)
            {
                Destroy(objectInstance);
                objectName.SetText("");
                objectDescription.SetText("");
            }

            var prefabToInspect = inspectableData.inspectionPrefab;
            if (prefabToInspect == null || spawnPoint == null)
            {
                Debug.LogError("Prefab to inspect or Spawn Point is not set!");
                return;
            }

            // Activate the inspection system object
            gameObject.SetActive(true);

            // Instantiate the prefab at the spawn point's position and rotation
            objectInstance = Instantiate(prefabToInspect, spawnPoint.position, spawnPoint.rotation);
            objectToInspect = objectInstance.transform;
            initialRotation = objectToInspect.rotation;
            
            // Enter the name and description of the object in the Inspector
            objectName.SetText(inspectableData.name);
            objectDescription.SetText(inspectableData.description);
        }

        /// <summary>
        /// This method ends the Inspector View by destroying the instantiated object and clearing the text boxes. This
        /// would set the game object that the inspector is under to false.
        /// </summary>
        public void EndInspection()
        {
            if (objectInstance != null)
            {
                Destroy(objectInstance);
            }
            // Deactivate the system so the Update loop stops running.
            gameObject.SetActive(false);
        }
        #endregion
        
        #region Unity Methods

        private void Update()
        {
            if (objectToInspect == null) return;

            // This temporarily uses right click to disable inspection
            if (Input.GetMouseButtonDown(1))
            {
                EndInspection();
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                prevMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 deltaMousePos = Input.mousePosition - prevMousePos;
                float rotationX = deltaMousePos.y * rotationSpeed * Time.deltaTime;
                float rotationY = -deltaMousePos.x * rotationSpeed * Time.deltaTime;

                Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
                objectToInspect.rotation = rotation * objectToInspect.rotation;

                prevMousePos = Input.mousePosition;
            }
        }

        #endregion
        
    }
}