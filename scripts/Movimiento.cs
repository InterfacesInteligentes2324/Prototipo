using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del personaje

    void Update()
    {
        Vector3 movimiento = Vector3.zero;

        // Mueve hacia adelante y atrás con W y S
        if (Input.GetKey(KeyCode.W))
        {
            movimiento += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movimiento += Vector3.back;
        }

        // Mueve hacia la derecha e izquierda con D y A
        if (Input.GetKey(KeyCode.D))
        {
            movimiento += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movimiento += Vector3.left;
        }

        // Normaliza el vector para asegurar velocidad constante en todas las direcciones
        movimiento.Normalize();

        // Mueve el personaje
        // REspecto a si mismo
        transform.Translate(movimiento * speed * Time.deltaTime, Space.Self);
    }
}
