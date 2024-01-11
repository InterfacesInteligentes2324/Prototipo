using System.Collections;
using UnityEngine;
using TMPro;

public class controlador_caja : MonoBehaviour
{
    public delegate void CollisionHandler();
    public static event CollisionHandler AddOnePoint;

    private bool Flagcaja = false;
    private bool keyLPressed = false;
    private float keyLStartTime = 0f;
    public float requiredHoldTime = 3f; // Tiempo necesario para mantener presionada la tecla L o fire1

    public delegate void SendHint(string hint, int id);
    public float speed = 2f; // Velocidad de movimiento (ajústala según sea necesario)

    public static event SendHint history_caja;

    public Renderer _myRenderer;
    public TMP_Text carta;
    public GameObject[] boxes;


    void Start()
    {

         boxes = GameObject.FindGameObjectsWithTag("box");

          foreach (GameObject box in boxes)
            {
                box.SetActive(false);
            }


        _myRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Mueve la caja hacia arriba si la tecla L está presionada y la caja ha sido mirada
        if ((Input.GetKey(KeyCode.L) || Input.GetButton("Fire1")) && Flagcaja)
        {
            // Si la tecla L o fire1 se ha presionado, inicia el temporizador
            if (!keyLPressed)
            {
                keyLPressed = true;
                keyLStartTime = Time.time;
            }

            // Obtén el desplazamiento en el eje Y en función de la velocidad y el tiempo
            float yOffset = speed * Time.deltaTime;

            // Translate mueve el objeto en el espacio local, por lo que usamos TransformDirection
            Vector3 displacement = transform.TransformDirection(Vector3.up) * yOffset;

            // Mueve el objeto hacia arriba
            transform.Translate(displacement);
        }
        else
        {
            // Si la tecla L o fire1 se ha soltado, reinicia el temporizador
            keyLPressed = false;
        }

        // Verifica si se ha mantenido presionada la tecla L o fire1 durante al menos 4 segundos
        if (keyLPressed && Time.time - keyLStartTime >= requiredHoldTime)
        {
            // Llama a history_caja solo si se ha mantenido presionada durante el tiempo requerido
            history_caja("Tras mover la caja, descubres una poción misteriosa. Aunque su propósito no es claro de inmediato, intuyes que podría ser crucial más adelante en tu aventura. Con la poción en tu posesión, tu siguiente objetivo se revela: encontrar una llave escondida que te permitirá abandonar la cabaña y continuar tu viaje", 3);
            keyLPressed = false; // Reinicia el temporizador después de llamar a history_caja
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        Debug.Log("Has mirado caja");
        if (!Flagcaja)
        {
            AddOnePoint();
            carta.text = "Mantén presionado sin parar el botón L para activar la magia y desplazar la caja";
            Flagcaja = true;
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        // Puedes agregar lógica adicional si es necesario cuando dejas de mirar la caja
    }
}
