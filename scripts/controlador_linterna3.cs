using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlador_linterna3 : MonoBehaviour
{
    public delegate void CollisionHandler();
    private bool FlagLinterna3 = false;
    public delegate void SendHint(string hint, int id);
    public static event CollisionHandler AddOnePoint;
    public static event SendHint history_linterna3;

    public static Renderer _myRenderer;
    public TMP_Text carta;


    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();

    }

    public void OnPointerEnter()
    {
        if (!FlagLinterna3)
        {
            AddOnePoint();
            Debug.Log("Has mirado el Linterna3");
            history_linterna3("Iluminas la nota con la linterna, revelando un mensaje que capta tu atención:\n\n'Has llegado muy lejos en este desafío. Para abrir el cofre del tesoro, resuelve este acertijo:\nOro parece, plata no es. El que no lo adivine, bien tonto es. ¿Qué es?'\n\nRecuerda, para añadir intriga y desafío, tu respuesta debe ser en inglés. Acércate al cofre y di la palabra mágica en voz alta.", 7);
            FlagLinterna3 = true;
        }
    }

    public void OnPointerExit()
    {
        Debug.Log("Has dejado de mirar el Linterna3");
    }
}
