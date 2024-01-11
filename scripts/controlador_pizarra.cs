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
public class controlador_pizarra : MonoBehaviour
{


    public delegate void CollisionHandler();
    public delegate void SendHint(string hint, int id);
    private bool FlagPizarra = false;
    public float speed = 10f; // Velocidad de movimiento

    public static event CollisionHandler AddOnePoint;
    public static event SendHint history_pizarra;

    public Renderer _myRenderer;

    public TMP_Text piz;

    private AudioSource audioSource;
    
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();

        // Código para el audio
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        if (!FlagPizarra) {
           
            AddOnePoint();
            Debug.Log("Has mirado a la pizarra");

            //piz.text = "Bienvenido jugador";

            history_pizarra("", 1);

            FlagPizarra = true;

            

        }

        // Reproducir el sonido
        Debug.Log(audioSource);
        if (audioSource != null && !audioSource.isPlaying) {
            Debug.Log("Audio reproduciendose");
            audioSource.Play();
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        Debug.Log("Has dejado de mirar a la pizarra");

        /* Detener el sonido al dejar de mirar la pizarra
        if (audioSource != null && audioSource.isPlaying) {
            Debug.Log("Audio detenido");
            audioSource.Stop();
        }
        */
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>

}
