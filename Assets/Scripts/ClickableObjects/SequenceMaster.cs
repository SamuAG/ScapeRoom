using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMaster : MonoBehaviour
{
    [SerializeField] private List<SequenceElement> sequenceElements;
    [SerializeField] private GameObject sequenceCompleted;
    private int currentIndex = 0; // Índice para llevar el seguimiento de la secuencia

    // Suscribimos a los eventos al iniciar
    void Start()
    {
        foreach (var sequenceElement in sequenceElements)
        {
            sequenceElement.OnElementChanged += (clickedElement) => OnElementChanged(clickedElement);
        }
    }

    // Este método se llama cuando cambia un elemento
    private void OnElementChanged(SequenceElement clickedElement)
    {
        // Verificamos si el clic corresponde al siguiente elemento de la secuencia
        if (clickedElement == sequenceElements[currentIndex])
        {
            Debug.Log($"Elemento {currentIndex + 1} correcto");

            currentIndex++; // Avanzar al siguiente elemento en la secuencia

            // Si hemos completado la secuencia
            if (currentIndex >= sequenceElements.Count)
            {
                Debug.Log("¡Secuencia completada!");
                // Aquí puedes ejecutar la acción que ocurra cuando se complete la secuencia
                SequenceCompleted();
            }
        }
        else
        {
            Debug.Log("Orden incorrecto, reiniciando secuencia...");
            // Reiniciar la secuencia si el clic no es en el orden correcto
            currentIndex = 0;
        }
    }

    // Lógica para cuando la secuencia ha sido completada
    private void SequenceCompleted()
    {
        // Puedes añadir la lógica aquí, como abrir una puerta o activar algo
        Debug.Log("¡Has completado la secuencia en el orden correcto!");
        sequenceCompleted.GetComponent<IInteractuable>().Activar();
    }
}
