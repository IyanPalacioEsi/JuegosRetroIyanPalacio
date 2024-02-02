using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTopGun : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI contador;

    public static ScoreTopGun tpInstance;
    private void Awake()
    {
        score = 0;

        contador.text = score.ToString();

        if (tpInstance == null)
            //La rrellenamos con todo el contenido de este script
            tpInstance = this;
    }

    public void ScorePoints()
    {
        score = 100 + score;

        contador.text = score.ToString();



    }
}
