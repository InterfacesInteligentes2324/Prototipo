using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using HuggingFace.API.Demos;
public class controlador_text : MonoBehaviour
{
    public delegate void CollisionHandler();

    public static event CollisionHandler AddOnePoint;
    public TMP_Text pointsText;
    public TMP_Text historyText;

    public delegate void MaletinRecogidoHandler();
    public static event MaletinRecogidoHandler AparecerLlave;



    private int points = 0;

    // Maletines
    private int maletinesRecogidos = 0;
    public TMP_Text maletinText;

    public GameObject[] boxes;
    public GameObject[] keys;



    // Start is called before the first frame update
    void Start()
    {


        controlador_pizarra.AddOnePoint += AddOne;
        controlador_pizarra.history_pizarra += Controller;

        controlador_caja.AddOnePoint += AddOne;
        controlador_caja.history_caja += Controller;

        controlador_libro.AddOnePoint += AddOne;
        controlador_libro.history_libro += Controller;

        controlador_llave.AddOnePoint += AddOne;
        controlador_llave.history_llave += Controller;

        controlador_treasure.AddOnePoint += AddOne;
        controlador_treasure.history_treasure += Controller;

        controlador_clipboard.AddOnePoint += AddOne;
        controlador_clipboard.history_clipboard += Controller;


        controlador_linterna3.history_linterna3 += Controller;
        controlador_linterna3.AddOnePoint += AddOne;

        boxes = GameObject.FindGameObjectsWithTag("box");
        keys = GameObject.FindGameObjectsWithTag("key");



        // Controlador del maletín que estará suscrito a los eventos
        SuitcaseController.MaletinRecogido += UpdateMaletinCount;
    }

    // Update is called once per frame
    void Update()
    {

        if(points==2){
            foreach (GameObject box in boxes)
                    {
                        box.SetActive(true);
                    }
        }

    }

    void AddOne()
    {
        points += 1;
        pointsText.text = "Contador: " + points.ToString() + "/7";
        

    }

    void Controller(string hint, int id)
    {
        if (id == points)
        {
            historyText.text = hint;
        } 

        

    }

    private void UpdateMaletinCount()
    {
        Debug.Log("Maletín recogido");
        maletinesRecogidos++; // Incrementa el contador
        Debug.Log(maletinesRecogidos);
        maletinText.text = maletinesRecogidos + "/5 maletines recogidos"; // Actualiza el texto
        /*if (maletinesRecogidos == 1)
        {
            historyText.text = "";
        }*/
        if (maletinesRecogidos == 1)
        {
            AddOne();
            AparecerLlave();
            historyText.text = "Excelente, has reunido todos los maletines. Aquí tienes la llave que desbloqueará la puerta hacia tu destino final.\n\nPresiona T (A en el mando) para usar la puerta";
            maletinText.text = "";
        }
    }
}
