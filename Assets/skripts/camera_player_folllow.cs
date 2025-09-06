using UnityEngine;

public class camera_player_follow : MonoBehaviour
{
    public Transform cameraPivot;
    public float mouseSensitivity = 2f;

    float xRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
