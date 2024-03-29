using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //Necesitamos un array de posiciones llamado Waypoints(puntos de ruta, las chinchetas).
    //Cada fantasma puede tener un n�mero de puntos de ruta distinto
    public Transform[] waypoints;
    //Inicializo la posici�n en la que se encuentra el fantasma. Posici�n 0 del array
    //Luego este valor ir� variando
    int currentWaypoint = 0;
    //Velocidad del fantasma
    public float speed = 0.3f;
    //Variable para saber si el fantasma es vulnerable
    public bool canDie;
    //Referencia al Rigidbody del fantasma
    public Rigidbody2D ghostRB;
    //Referencia al Animator del fantasma
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody
        ghostRB = GetComponent<Rigidbody2D>();
        //Inicializamos el Animator
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Si PacMan sigue siendo invencible
        if (GameManagerPacMan.gmSharedInstance.invincibleTime > 0)
        {
            //El fantasma cambia a azul
            anim.SetBool("PacManInvencible", true);
            //El fantasma puede morir
            canDie = true;
        }
        else
        {
            //El fantasma queda como al principio
            anim.SetBool("PacManInvencible", false);
            //El fantasma no puede morir
            canDie = false;
        }
            
    }

    // Usamos Fixed porque es un movimiento f�sico y continuo y autom�tico
    void FixedUpdate()
    {
        //Distancia al punto de ruta, entre la posici�n actual del fantasma
        // y el punto de ruta hacia el que se est� dirigiendo
        float distanceToWaypoint = Vector2.Distance(transform.position, waypoints[currentWaypoint].position);
        //Debug.Log(distanceToWaypoint);

        //Si la distancia hasta el punto de ruta es menor que 0.1 es que he llegado a la posici�n
        if(distanceToWaypoint < 0.1f)
        {
            //Ir al siguiente Waypoint. Lo de abajo es equivalente a la siguiente l�nea
            //Esto es un operador ternario. => condicion ? consecuencia : alternativa
            //currentWaypoint = (currentWaypoint < waypoints.Length - 1) ? currentWaypoint += 1 : currentWaypoint = 0;
            //Si el n�mero del punto en el que est� el fantasma es menor
            //que la cantidad de los que hay guardados
            if (currentWaypoint < waypoints.Length - 1)
                //Avanzamos al siguiente punto
                currentWaypoint++;
            //Si por el contrario el n�mero del punto en el que est� el fantasma
            //es igual o mayor que los que hay guardados
            else
                //Reseteamos al primer punto de los guardados
                currentWaypoint = 0;

            //Nueva direcci�n para calcular la animaci�n si cambiamos de direcci�n:
            //donde va - donde est� ahora
            Vector2 newDirection = waypoints[currentWaypoint].position - transform.position;
            //Cambiamos las animaciones
            anim.SetFloat("DirX", newDirection.x);
            anim.SetFloat("DirY", newDirection.y);

        }
        //Si el fantasma a�n no ha llegado a su destino
        else
        {
            //Creo un Vector2 para moverme desde donde est� el fantasma ahora mismo,
            //hasta el siguiente Waypoint a una velocidad
            Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            //Hacemos que se mueva a la posici�n que le toca
            ghostRB.MovePosition(newPos);
        }
    }

    //M�todo para conocer la reacci�n de un fantasma al impactar contra PacMan
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto que se ha metido en el trigger del fantasma es el jugador y el enemigo no puede morir
        if (collision.CompareTag("Player") && !canDie)
        {
            //Destruye a PacMan
            Debug.Log("Jugador muerto");
            //Destruye a PacMan(obteniendo de este GameObject, su c�digo para poder coger de �l el m�todo de PacManDead())
            collision.gameObject.GetComponent<PacManMovement>().PacManDead();
        }
    }
}
