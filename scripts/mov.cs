using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class mov : MonoBehaviour
{


    void Start(){
        Input.location.Start();
        Input.gyro.enabled = true;
        Input.compass.enabled=true;
    }
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, 
        Quaternion.Euler(0, -Input.compass.trueHeading, 0), 0.7f);
    }
}