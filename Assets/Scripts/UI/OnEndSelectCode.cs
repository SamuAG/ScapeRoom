using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnEndSelectCode : MonoBehaviour
{
    [SerializeField] private string correctCode = "0000"; // Código correcto
    [SerializeField] private TMP_InputField inputField; // Campo de texto del input
    [SerializeField] private List<GameObject> interactuables; // Lista de objetos interactuables
    [SerializeField] private Color correctColor = Color.green; // Color si el código es correcto
    [SerializeField] private Color incorrectColor = Color.red; // Color si el código es incorrecto
    [SerializeField] private float resetColorDelay = 2f; // Tiempo para restaurar el color inicial

    private Color initialColor; // Almacena el color original del texto

    void Start()
    {
        // Guardamos el color inicial del texto
        initialColor = inputField.textComponent.color;

        // Añadimos el listener al evento de fin de edición del inputField
        inputField.onEndEdit.AddListener(OnEndSelect);
    }

    public void OnEndSelect(string inputCode)
    {
        // Comprobar si el código introducido es correcto
        if (inputCode == correctCode)
        {
            Debug.Log("¡Código correcto!");
            inputField.textComponent.color = correctColor;

            // Deshabilitar la edición del campo de texto
            inputField.interactable = false;

            // Activamos todos los objetos interactuables
            foreach (var interactuable in interactuables)
            {
                interactuable.GetComponent<IInteractuable>().Activar();
            }
        }
        else
        {
            Debug.Log("¡Código incorrecto!");
            inputField.textComponent.color = incorrectColor;

            inputField.interactable = false;

            // Restaurar el color inicial del texto después de un retraso
            StartCoroutine(ResetTextColorAfterDelay());
        }
    }

    private IEnumerator ResetTextColorAfterDelay()
    {
        // Espera el tiempo definido antes de restaurar el color
        yield return new WaitForSeconds(resetColorDelay);
        inputField.textComponent.color = initialColor;
        inputField.text = "";
        inputField.interactable = true;
    }
}
