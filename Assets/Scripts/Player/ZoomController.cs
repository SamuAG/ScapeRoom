using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public Camera cameraToZoom; // Cámara a la que se le aplicará el zoom
    public float zoomSpeed = 10f; // Velocidad del zoom
    public float minFov = 20f; // Valor mínimo del FOV (más cerca)
    public float maxFov = 60f; // Valor máximo del FOV (más lejos)

    private void Start()
    {
        // Si no has asignado una cámara en el inspector, se usa la principal
        if (cameraToZoom == null)
        {
            cameraToZoom = Camera.main;
        }
    }

    void Update()
    {
        // Obtener el valor de la ruleta del ratón
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Ajustar el FOV según la entrada de la ruleta del ratón
        if (scrollInput != 0f)
        {
            cameraToZoom.fieldOfView -= scrollInput * zoomSpeed;
            // Limitar el FOV dentro de los valores mínimo y máximo
            cameraToZoom.fieldOfView = Mathf.Clamp(cameraToZoom.fieldOfView, minFov, maxFov);
        }
    }
}
