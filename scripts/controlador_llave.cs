//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using TMPro;


/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class controlador_llave : MonoBehaviour
{

    public delegate void CollisionHandler();
    public static event CollisionHandler AddOnePoint;


    private bool FlagLlave = false;

    public delegate void SendHint(string hint, int id);
    public static event SendHint history_llave;

    public delegate void Telet();
    public static event Telet teleTransportar_casa1;

    public Renderer _myRenderer;

    public TMP_Text carta;

    public GameObject[] keys;



    public void Start()
    {
       
        _myRenderer = GetComponent<Renderer>();

    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        if (!FlagLlave)
        {
            AddOnePoint();
            Debug.Log("Has mirado a llave 1");

            history_llave("¡Vaya rapidez! ¿Ya has hallado la llave? Es hora de marcharnos. Continuemos nuestra exploración\n\nPresiona T para usar la puerta", 4);
            FlagLlave = true;
        }
    }

    public void Update()
    {

        if (FlagLlave)
        {

            // Input de la T o del botónA en el mando
            if (Input.GetKey(KeyCode.T) || Input.GetButton("Fire1"))
            {
                Debug.Log("Moviendo a casa 2....");
                

                teleTransportar_casa1();
                carta.text = "Oyes una voz:\n\nNo temas, gracias a la poción que tomaste, puedo comunicarme contigo directamente, evitando dejar mensajes. La próxima prueba te aguarda: recoge los maletines. No te preocupes por su contenido; tras ello, recibirás tu recompensa.";
                FlagLlave = false;
            }

        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {

    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
}
