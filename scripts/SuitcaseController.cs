using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseController : MonoBehaviour
{
    public delegate void MaletinRecogidoHandler();
    public static event MaletinRecogidoHandler MaletinRecogido;
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colision");
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Colision con el jugador");
            
            MaletinRecogido?.Invoke();

            // Hacer desaparecer el maletín
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aplica una pequeña fuerza hacia arriba para que el maletín salte
        GetComponent<Rigidbody>().AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
    }
}
