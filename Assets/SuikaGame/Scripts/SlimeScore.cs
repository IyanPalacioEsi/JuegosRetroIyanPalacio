using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlimeScore : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI contador;

    public static SlimeScore ssInstance;

    private void Awake()
    {
        score = 0;

        contador.text = score.ToString();

        if (ssInstance == null)
            //La rrellenamos con todo el contenido de este script
            ssInstance = this;
    }

    public void ScorePoints()
    {
        score = 1 + score;

        contador.text = score.ToString();



    }
}
