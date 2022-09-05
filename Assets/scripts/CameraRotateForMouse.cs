using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateForMouse : MonoBehaviour
{
    [SerializeField] private float sensitivityX = 1.0f, sensitivityY = 1.0f;

    private float _xRotation = 0.0f;
    private float _yRotation = 0.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0.0f);

        float horizontal = Input.GetAxis("Horizontal");
        transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, horizontal / 2, 0.1f), transform.position.y, transform.position.z);
    }
}
