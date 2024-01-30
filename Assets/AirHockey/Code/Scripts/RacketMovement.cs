using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    //Velocidad de la raqueta
    public float racketSpeed = 25f;
    public string axe;
    //Esto es una referencia al RigidBody del jugador que nos permite cambiar su velocidad
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //As� inicializar�amos el RigidBody desde c�digo
        //rb = GetComponent<Rigidbody2D>();
    }

    // Ponemos FixedUpdate para que la longitud de cada frame en segundos mida lo mismo, y as� el movimiento sea suavizado
    void FixedUpdate()
    {
        
        //Creo una referenca al eje que quiero utilizar
        float verticalMovement = Input.GetAxis(axe);
        //Va al componente Rigidbody y le aplicamos una velocidad, que es un Vector2 donde en este caso no lo movemos en X solo en Y
        rb.velocity = new Vector2(0f, verticalMovement) * racketSpeed; //Multiplicamos por la velocidad de movimiento => 1*25 � -1*25

       

    }
}
