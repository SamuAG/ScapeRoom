using System.Collections.Generic;
using UnityEngine;

public class LeverMaster : MonoBehaviour
{
    [SerializeField] List<LeverState> leverStates = new List<LeverState>();
    [SerializeField] GameObject door; // Puerta que se activará

    private void Start()
    {
        // Suscribirse al evento de cada palanca
        foreach (LeverState leverState in leverStates)
        {
            leverState.Lever.OnLeverStateChanged += () => CheckAllLeverStates();
        }
    }

    private void CheckAllLeverStates()
    {
        if (door.GetComponent<IInteractuable>() == null) return;
        // Verificar si todos los estados de las palancas coinciden con los booleanos esperados
        bool allCorrect = true;
        foreach (LeverState leverState in leverStates)
        {
            if (leverState.Lever.IsOn != leverState.IsOn)
            {
                allCorrect = false;
                break; // Si alguna palanca no coincide, detener la verificación
            }
        }

        // Si todas las palancas están en el estado correcto, activar la puerta
        if (allCorrect)
        {
            door.GetComponent<IInteractuable>().Activar(); // Activar la puerta
            Debug.Log("¡Todas las palancas están en el estado correcto! Puerta activada.");
        }
        else
        {
            Debug.Log("Las palancas no están en el estado correcto.");
        }
    }
}

[System.Serializable]
public class LeverState
{
    [SerializeField]
    Lever lever;
    [SerializeField]
    bool isOn;

    public Lever Lever { get => lever; set => lever = value; }
    public bool IsOn { get => isOn; set => isOn = value; }
}
