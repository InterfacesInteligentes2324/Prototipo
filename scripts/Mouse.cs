using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del ratón.
    public Transform playerBody; // Referencia al cuerpo del jugador, para rotar alrededor del eje Y.

    private float xRotation = 0f; // Rotación acumulada en el eje X.

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro de la pantalla.
    }

    void Update()
    {
        // Obtiene el movimiento del ratón.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calcula la rotación en el eje X y la aplica.
        xRotation -= mouseY; // Invierte el eje Y para que el movimiento sea intuitivo.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación para evitar dar vuelta completa.

        // Aplica la rotación en el eje X solamente a la cámara.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota el cuerpo del jugador alrededor del eje Y.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
