using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;
    public float minFov = 15f;
    public float maxFov = 67f;
    public float minOrthographicSize = 1f;
    public float maxOrthographicSize = 20f;

    [Header("Position Settings")]
    public float turnSpeed = 4.0f;
    
    [Header("Camera Pivot")]
    public Transform target; // The point the camera orbits around
    
    // Private Variables
    private Camera _camera;
    private float _distance; // The distance from the camera to the target
    private float _rotationX;
    private float _rotationY;

    void Start()
    {
        _camera = GetComponent<Camera>();
        if (target != null)
        {
            // Set initial rotation based on where you've placed the camera in the Scene
            Vector3 angles = transform.eulerAngles;
            _rotationX = angles.y;
            _rotationY = angles.x;

            // Store the initial distance from the target
            _distance = Vector3.Distance(transform.position, target.position);
        }
    }

    void Update()
    {
        // This zoom logic remains the same.
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            if (_camera.orthographic)
            {
                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - scroll * zoomSpeed, minOrthographicSize, maxOrthographicSize);
            }
            else
            {
                float fov = _camera.fieldOfView;
                fov -= scroll * zoomSpeed * 5;
                fov = Mathf.Clamp(fov, minFov, maxFov);
                _camera.fieldOfView = fov;
            }
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Only rotate if the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            // Get mouse input and update the rotation angles
            _rotationX += Input.GetAxis("Mouse X") * turnSpeed;
            _rotationY -= Input.GetAxis("Mouse Y") * turnSpeed;

            // Clamp the vertical angle to prevent flipping and going below the target
            // This keeps the camera from pointing straight up or down.
            _rotationY = Mathf.Clamp(_rotationY, -0f, 89f);
        }

        // Convert the Euler angles into a rotation quaternion
        Quaternion rotation = Quaternion.Euler(_rotationY, _rotationX, 0);

        // Calculate the camera's position by starting at the target, applying the
        // calculated rotation, and then moving backward by the stored distance.
        Vector3 position = target.position - (rotation * Vector3.forward * _distance);

        // Apply the calculated rotation and position to the camera's transform
        transform.rotation = rotation;
        transform.position = position;
    }
}