using System.Collections;
using UnityEngine;
using TMPro;

public class controlador_llave_seg : MonoBehaviour
{
    public delegate void CollisionHandler();
    private bool FlagLlave = false;
    public delegate void SendHint(string hint, int id);
    public static event CollisionHandler AddOnePoint;
    public static event SendHint history_llave;

    public delegate void Telet();
    public static event Telet teleTransportar_casa2;
    public delegate void MaletinRecogidoHandler();
    public static event MaletinRecogidoHandler AparecerLlave;

    public Renderer _myRenderer;

    public TMP_Text carta;

    void Start()
    {
        _myRenderer = GetComponent<Renderer>();


        controlador_text.AparecerLlave += llaveOn;

        // Desactivar el GameObject si tiene el tag "key"
        if (gameObject.CompareTag("key2"))
        {
            gameObject.SetActive(false);
        }
    }

    void llaveOn()
    {

        if (gameObject.CompareTag("key2"))
        {
            gameObject.SetActive(true);
        }

    }

    void Update()
    {
        if (FlagLlave)
        {
            // Input de la T o del botón A en el mando
            if (Input.GetKey(KeyCode.T) || Input.GetButton("Fire1"))
            {
                Debug.Log("Moviendo a casa 2....");
                teleTransportar_casa2();
                carta.text = "Te encuentras en la última etapa del juego. Ante ti, reposa un cofre sobre la encimera, aguardando ser descubierto. Dentro esconde un tesoro, cuya llave es una palabra secreta. Esta palabra se halla oculta en una nota, escondida en algún rincón de la casa.\n¿Serás capaz de encontrarla a tiempo y desvelar el secreto del cofre?";
                FlagLlave= false;
            }
        }
    }

    public void OnPointerEnter()
    {
        if (!FlagLlave)
        {
            Debug.Log("Has mirado a llave 2");
            FlagLlave = true;
        }
    }

    public void OnPointerExit()
    {
        // Implementa según sea necesario
    }
}
