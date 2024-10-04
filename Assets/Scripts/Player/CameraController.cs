using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float minXRotation = -45f; // L�mite inferior para la rotaci�n en X
    public float maxXRotation = 45f;  // L�mite superior para la rotaci�n en X
    private Vector3 previousMousePosition;
    private float currentXRotation = 0f; // Para controlar el �ngulo acumulado en X

    void Update()
    {
        // Detectar cuando se hace clic
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }

        // Si se arrastra el rat�n
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;

            // Rotar alrededor del eje Y (horizontal)
            transform.Rotate(Vector3.up, -mouseDelta.x * rotationSpeed * Time.deltaTime, Space.World);

            // Rotar en el eje X (vertical) con clamp
            float rotationX = -mouseDelta.y * -rotationSpeed * Time.deltaTime; // Invertir el valor en Y
            currentXRotation = Mathf.Clamp(currentXRotation + rotationX, minXRotation, maxXRotation);

            // Aplicar la rotaci�n limitada
            transform.localEulerAngles = new Vector3(currentXRotation, transform.localEulerAngles.y, 0);

            previousMousePosition = Input.mousePosition;
        }
    }
}
