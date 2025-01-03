using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePositionChecker : MonoBehaviour
{
    public Transform objectA; // Primer objeto de referencia
    public Transform objectB; // Segundo objeto de referencia
    public float tolerance = 0.1f; // Tolerancia para considerar posiciones cercanas

    public Beetle beetle;

    void Update()
    {
        if (objectA != null)
        {
            CheckRelativePosition(objectA, "Objeto A");
        }

        if (objectB != null)
        {
            CheckRelativePosition(objectB, "Objeto B");
        }
    }

    void CheckRelativePosition(Transform target, string objectName)
    {
        float deltaX = transform.position.x - target.position.x;
        float deltaY = transform.position.y - target.position.y;

        // Detectar si está alineado en X o Y dentro de la tolerancia
        bool alignedX = Mathf.Abs(deltaX) <= tolerance;
        bool alignedY = Mathf.Abs(deltaY) <= tolerance;

        // Detectar direcciones
        if (alignedX && deltaY > tolerance)
        {
            Debug.Log($"{objectName}: ¡Está abajo!");
            // beetle.GoingToDown();
        }
        else if (alignedX && deltaY < -tolerance)
        {
            Debug.Log($"{objectName}: ¡Está arriba!");
            // beetle.GoingToUp();
        }
        else if (alignedY && deltaX > tolerance)
        {
            Debug.Log($"{objectName}: ¡Está a la derecha!");
        }
        else if (alignedY && deltaX < -tolerance)
        {
            Debug.Log($"{objectName}: ¡Está a la izquierda!");
        }
        else if (alignedX && alignedY)
        {
            Debug.Log($"{objectName}: ¡Está en la misma posición!");
        }
    }
}
