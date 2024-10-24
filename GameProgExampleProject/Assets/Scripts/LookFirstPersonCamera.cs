using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LookFirstPersonCamera : MonoBehaviour
{
    public float sensX = 500f;
    public float sensY = 500f;

    public new Transform camera;
    public float eyeHeight = 1f;

    //Private Varibles
    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

  
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.5f);
    }
}
