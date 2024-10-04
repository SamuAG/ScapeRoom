using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puerta : MonoBehaviour, IInteractuable
{
    public void Activar()
    {
        Debug.Log("Puerta abierta");
        StartCoroutine(MoveDoor());
    }

    private IEnumerator MoveDoor()
    {
        Vector3 initialPosition = transform.position;
        // mover la puerta hacia arriba
        while (transform.position.y < initialPosition.y + 5)
        {
            transform.position += Vector3.up * Time.deltaTime;
            yield return null;
        }

        Destroy(this);
    }
}
