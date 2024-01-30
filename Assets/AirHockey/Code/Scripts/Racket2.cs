using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket2 : MonoBehaviour
{
    public float racketSpeed = -25f;
    public float HorizontalSpeed = -25f;
    float VerticalSpeed = -25f;
    public Rigidbody2D rb;
    
    void Start()
    {
        
    }


    void Update()
    {

        float HorinzontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        float verticalMovement = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(0f, verticalMovement) * racketSpeed;
        
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            Vector3 position = transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            
            Vector3 position = transform.position;
            position.y++;
            this.transform.position = position;
        }
    }
}
