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
public class controlador_libro : MonoBehaviour
{

    public delegate void CollisionHandler();
    private bool Flaglibro = false;
    public delegate void SendHint(string hint, int id);
    public float speed = 10f; // Velocidad de movimiento
    public static event CollisionHandler AddOnePoint;
    public static event SendHint history_libro;

    public Renderer _myRenderer;

    public TMP_Text carta;


    public void Start()
    {
        
        _myRenderer = GetComponent<Renderer>();

    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {

        if (!Flaglibro)
        {
            //SESION 2
            //Mismo codigo que el de mover las arañas hacia el zombie pero al reves.
            AddOnePoint();
            Debug.Log("Has mirado a libro");

            history_libro("Con los misterios del tomo ahora revelados, posees el don de mover objetos mediante la magia. Busca una caja y experimenta el poder de tu recién adquirida habilidad", 2);
           

            Flaglibro = true;
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
