using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAirHockey : MonoBehaviour
{
    //Referencia guarda direccion disco
    Vector2 direction;

    //Referencia disco
    public GameObject disk;

    public GameObject PlayerLeft, PlayerRight;

    public void GoalScored() 
    {
        disk.transform.position = Vector2.zero;

        PlayerLeft.transform.position = new Vector2(-6.75f, 0f);
        PlayerRight.transform.position = new Vector2(6.75f, 0f);

        direction = new Vector2(-disk.GetComponent<Rigidbody2D>().velocity.x, 0f);

        disk.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


    }

    void LaunchDisk() 
    {
        disk.GetComponent<Rigidbody2D>().velocity = direction;
    }
}
