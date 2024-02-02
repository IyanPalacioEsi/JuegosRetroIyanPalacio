using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosTetris : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI contador;

    public static PuntosTetris ptInstance;
    private void Awake()
    {
        score = 0;

        contador.text = score.ToString();

        if (ptInstance == null)
            //La rrellenamos con todo el contenido de este script
            ptInstance = this;
    }

    public void ScorePoints() 
    {
        score = 100 + score;

        contador.text = score.ToString();



    }
}
