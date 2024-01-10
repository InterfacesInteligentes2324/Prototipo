using UnityEngine;

public class p1_A : MonoBehaviour
{
    public float speed = 5f;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public delegate void Telet();
    public static event Telet teleTransportar_casa2;
    public static event Telet teleTransportar_casa1;

    void Start()
    {
       controlador_llave.teleTransportar_casa1+=TeleTransportar_lugar1;
       controlador_llave_seg.teleTransportar_casa2+=TeleTransportar_lugar2;

    }

    void Update()
    {   
        //Debug.Log("Nueva posición: " + transform.position);

        float horizontalInput = Input.GetAxis(horizontalAxis);
        float verticalInput = Input.GetAxis(verticalAxis);

        transform.Rotate(Vector3.up, horizontalInput * 180.0f * Time.deltaTime);
        Vector3 displacement = new Vector3(0.0f, 0.0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(displacement);
    }

    void TeleTransportar_lugar1()
    {
        // Implement your teletransportation logic here
        Debug.Log("Teletransportando a angar");
        transform.position = new Vector3(-1.0f, 5.09f, -52.0f);
    }
    void TeleTransportar_lugar2()
    {
        // Implement your teletransportation logic here
        Debug.Log("Teletransportando a casa laura");
        transform.position = new Vector3(-72f, 5f, 23f);
    }
}
