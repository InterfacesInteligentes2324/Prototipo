using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlador_clipboard : MonoBehaviour
{

    public delegate void CollisionHandler();
    private bool FlagClipboard = false;
    public delegate void SendHint(string hint, int id);
    public static event CollisionHandler AddOnePoint;
    public static event SendHint history_clipboard;

    public Renderer _myRenderer;
    public TMP_Text carta;


    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();

    }

    public void OnPointerEnter()
    {
        if (!FlagClipboard)
        {
            AddOnePoint();
            Debug.Log("Has mirado el clipboard");
            history_clipboard("Descubres una nota, pero, para tu sorpresa, parece estar vacía.\n\nDe repente, una voz misteriosa te susurra:'Prueba con algo más que la vista común, como una luz especial.\nTal vez una linterna mágica revele lo invisible'", 6);
            FlagClipboard = true;
        }
    }

    public void OnPointerExit()
    {
        Debug.Log("Has dejado de mirar el clipboard");
        gameObject.SetActive(false);
    }
}
