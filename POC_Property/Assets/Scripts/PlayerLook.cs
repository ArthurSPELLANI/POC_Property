using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 100f;

    float xRotation = 0f;

    public Transform playerBody;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float axisX = Input.GetAxis("RHorizontal") * sensitivity * Time.deltaTime;
        float axisY = Input.GetAxis("RVertical") * sensitivity * Time.deltaTime;

        xRotation -= axisY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * axisX);
    }
}
