using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para poder cambiar entre escenas

public class MainMenuAdventureText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Si pulsamos las teclas arriba y abajo asignadas en el eje vertical, el selector se va a mover arriba o abajo
        ////Si estamos pulsando arriba
        //if (Input.GetAxis("Vertical") == 1) 
        //{
        //    //Que el selector vaya a la posicion. Coge la posicion de este obbjeto en el transform y le cambia por el Vector que le pasamos
        //    transform.position = new Vector2(-5f, -2.8f);
        //}
        ////Si estamos pulsando abajo
        //else if(Input.GetAxis("Vertical")== -1) 
        //{
        //    //Que el selector vaya a la posicion. Coge la posicion de este obbjeto en el transform y le cambia por el Vector que le pasamos
        //    transform.position = new Vector2(-5f, -4.6f);
        //}
        ////Si lo hacemos de esta manera el movimiento, se hace una vez cada bucle total de juego
        ////Da igual los FPS, se hara una vez por segundo

        ////Si pulsamos las teclas arriba y abajo, el selector se va a mover arriba o abajo
        ////Si estamos pulsando arriba
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Que el selector vaya a la posicion. Coge la posicion de este obbjeto en el transform y le cambia por el Vector que le pasamos
          transform.position = new Vector2(-5f, -2.8f);
        }
        ////Si estamos pulsando abajo
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            //Que el selector vaya a la posicion. Coge la posicion de este obbjeto en el transform y le cambia por el Vector que le pasamos
            transform.position = new Vector2(-5f, -4.6f);
        }
        ////Si lo hacemos de esta manera el movimiento, se hace una vez cada bucle total de juego
        ////Da igual los FPS, se hara una vez por segundo
        
        //Si el player esta en la posicion de juego nuevo y pulsamos la tecla intro
        if(transform.position.y == -2.8f && Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            //Cargamos la escena con ese nombre
            SceneManager.LoadScene("GameAdventureText");
        }
        
    }

}
