using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Libreria para acceder textmeshpro

public class GoalZone : MonoBehaviour
{
    //REferencia acceder marcador de ppuntos
    public TextMeshProUGUI scoreText;
    //Variable guardar puntos guardados porteria
    int score;

    public GameManagerAirHockey gMReference;

    //Antes de que empieze el juego
    private void Awake()
    {
        //Ponemos puntuacion en cero
        score = 0;
        //cambiamos el texto de la puntuacion al valor que tenga en ese momento el score
        scoreText.text = score.ToString();

        //Para transformar int en string hay 3 formas
        //score.Text.text = score + "";
        //scoreText.text = score.ToString();
        //scoreText.text = "Score" + score;
    }

    //Metodo para detectar cuando algo entra en un trigger(GoalZone)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo aquellos gameobject nombrado disco que entra en trigger
        if (collision.CompareTag("Disco")) 
        {
            //Sumo 1 a la puntuacion
            score++;
            //cambiamos el texto de la puntuacion al valor que tenga en ese momento el score
            scoreText.text = score.ToString();
            gMReference.GoalScored();
        }
        

    }


}
