using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Obtener la c�mara principal
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // Hacer que el objeto mire siempre a la c�mara
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up);
    }
}
