using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;  // Movement speed
    public float mouseSensitivity = 100.0f;  // Mouse sensitivity
    public float sprintMultiplier = 2.0f;  // Speed multiplier for sprinting

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for looking around
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);  // Clamp the vertical rotation

        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0.0f);

        // Get keyboard input for movement
        float moveForwardBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveLeftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Check if left shift is held down to double the speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveForwardBackward *= sprintMultiplier;
            moveLeftRight *= sprintMultiplier;
        }

        // Move the camera
        transform.Translate(new Vector3(moveLeftRight, 0.0f, moveForwardBackward));
    }
}
