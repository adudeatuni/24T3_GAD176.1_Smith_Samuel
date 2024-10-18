using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCam : MonoBehaviour
{

    public float sensitvX;
    public float sensitvY;

    public Transform playerOrientation;
    float rotationX;
    float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // get input from mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime *sensitvX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime *sensitvY;

        rotationY += mouseX;
        rotationX -= mouseY;
        
        // Locks up/down between 90 and -90 degrees (prevents player from "rolling" the camera, they can look all the way up, or down, but can't go further
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Top rotates camera, bottom rotates player
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        playerOrientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
