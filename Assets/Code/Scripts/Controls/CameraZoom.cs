using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float minFov = 15f;
    public float maxFov = 67f;
    public float minOrthographicSize = 1f;
    public float maxOrthographicSize = 20f;

    private Camera _camera;

    public float turnSpeed = 4.0f;
    public Transform target; // The point the camera orbits around
    private Vector3 offset;

    void Start()
    {
        _camera = GetComponent<Camera>();
        offset = transform.position - target.position;
    }

    void Update()
    {
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
                fov -= scroll * zoomSpeed;
                fov = Mathf.Clamp(fov, minFov, maxFov);
                _camera.fieldOfView = fov;
            }
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float x = Input.GetAxis("Mouse X") * turnSpeed;
            float y = Input.GetAxis("Mouse Y") * turnSpeed;

            offset = Quaternion.AngleAxis(x, Vector3.up) * offset;
            offset = Quaternion.AngleAxis(y, Vector3.right) * offset;

            transform.position = target.position + offset;
            transform.LookAt(target);
        }

        // Clamp y-position to be positive.
        transform.position = new Vector3(transform.position.x, Mathf.Abs(transform.position.y), transform.position.z);
    }
}