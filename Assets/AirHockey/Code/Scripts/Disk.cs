using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    //Velocidad del disco
    public float diskSpeed = 25f;
    //Esto es una referencia al RigidBody del disco que nos permite cambiar su velocidad
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //El disco empieza con una velocidad que lo impulsa a la derecha
        rb.velocity = Vector2.right * diskSpeed; //Equivale a new Vector2(1,0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* El objeto collision del parentesis contiene la informacion del
     * En particular, no interesa saber cuando choca contra una pala
     * -collision.gameobject: tiene informacion del pbjeto contra el
     * -collision.tranform.position: tiene informacion de la po
     * -collision.collider:
    /* Es un metodo de unity que detecta colision entre dos GO.
     * Al chocar el objeto contra el que choca le pasa su Colision. */ 
    private void OnCollisionEnter2D(Collision2D collision) //El parametro collision es el objeto que ha chocado contra el disco
    {
        //Si el disco colisiona con la pala izquierda
        if (collision.gameObject.name == "PlayerLeft") 
        {
            //Obtenemos el factor de golpeo, pasandole la posicion del disco, la pala y lo que mide el collider de la pala
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            /*Le damos una nueva direccion al disco
             * en este caso con una x a la derecaha
             * y nuestro factor vde ggiolpèo colacalcualado
             * normalizardpado todo rlrel vercto*/
            Vector2 direction = new Vector2(1, yF).normalized;
            //le decimos al dicoa qe dsal gpa
            rb.velocity = direction * diskSpeed;
        }

        
        if (collision.gameObject.name == "PlayerRight")
        {
            
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            
            Vector2 direction = new Vector2(-1, yF).normalized;
            
            rb.velocity = direction * diskSpeed;
        }
    }
    /* 1 - el disco choca contra la parte superior de la pala
     * 0 - choca centro pala
     * -1 - choca parte inferior pala*/
    /*
     * Es un metodo de tipo 3. en est caso le pasamos 3 parametros 
     * -posichoionn diosco
     * l-posdibhcion polapla
     * altiura pala
     * y el metodo tal y nos devuelve
     */
    private float HitFactor(Vector2 diskPosition, Vector2 racketPosition, float racketHeight) 
    {
        return (diskPosition.y - racketPosition.y) / racketHeight;
    }
}
