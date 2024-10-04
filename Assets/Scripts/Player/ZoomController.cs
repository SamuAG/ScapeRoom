using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public Camera cameraToZoom; // C�mara a la que se le aplicar� el zoom
    public float zoomSpeed = 10f; // Velocidad del zoom
    public float minFov = 20f; // Valor m�nimo del FOV (m�s cerca)
    public float maxFov = 60f; // Valor m�ximo del FOV (m�s lejos)

    private void Start()
    {
        // Si no has asignado una c�mara en el inspector, se usa la principal
        if (cameraToZoom == null)
        {
            cameraToZoom = Camera.main;
        }
    }

    void Update()
    {
        // Obtener el valor de la ruleta del rat�n
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Ajustar el FOV seg�n la entrada de la ruleta del rat�n
        if (scrollInput != 0f)
        {
            cameraToZoom.fieldOfView -= scrollInput * zoomSpeed;
            // Limitar el FOV dentro de los valores m�nimo y m�ximo
            cameraToZoom.fieldOfView = Mathf.Clamp(cameraToZoom.fieldOfView, minFov, maxFov);
        }
    }
}
