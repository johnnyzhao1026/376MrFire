using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //playerBody = GameObject.Find("PlayerBody").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // look up down
        yRotation += mouseX; // look left right
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // lock the mouse not over rotation vertically

        transform.localRotation = Quaternion.Euler(xRotation,0f, 0f); // camera rotation
        playerBody.Rotate(Vector3.up * mouseX); // axis rotate around Y Axis, body look around horizontal

    }


}
