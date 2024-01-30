using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1942 : MonoBehaviour
{
    //Variable para la velocidad del avión
    public float moveSpeed;
    //Número de vidas que tiene el jugador
    public int lifes = 3;
    //Referencia al RB
    public Rigidbody2D rb;
    //Referencia a la bala
    public GameObject bullet;
    //Referencia al punto de disparo del avión
    public Transform firePoint;
    //Referencia a la UI
    public UIController1942 uiReference;
    //Referencia al GameManager
    public GameManager1942 gmReference;
    //Referencia a la cámara del juego
    public Camera mainCamera;
    //Vector para controlar la posición relativa a lo que ve la cámara
    Vector3 viewPosition;

    float leftContraint;

    float rightContraint;
    //Sirve para que la nave desaparezca pasado el borde de la camara mas esta cantidad
    float offset = .05f;

    private void Start()
    {
        //Inicializamos la referencia al Rigidbody
        //rb = GetComponent<Rigidbody2D>();
        //Le damos valores a esas restriciones
        //busca un punto en el espacio de unity relativo al mismo punto de lo que ve la camara
        //Screen.width es el tamaño de la pantalla de ancho de lo que ve la camara
        leftContraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.05f, 0.0f, 0.0f)).x;

        rightContraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.95f, 0.0f, 0.0f)).x;

    }

    void Update()
    {
        //Movimiento en las 4 direcciones y en diagonal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed;
        //Si la nave se ha salido por la izquierda o la derecha de lo que ve la cámara
        if (transform.position.x < leftContraint - offset)
            transform.position = new Vector2(rightContraint + offset, transform.position.y);

        if (transform.position.x > rightContraint - offset)
            transform.position = new Vector2(leftContraint - offset, transform.position.y);

        //Le damos la vuelta al valor en X de la posición de la nave
        transform.position = new Vector2(transform.position.x * -1, transform.position.y);

        //Si pulsamos para disparar una bala
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Crear un objeto es crear una instancia que es una unidad de algo
            //Le pasamos el objeto que queremos que aparezca, en la posición y rotación que queremos que aparezca
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            //Sonido al disparar una bala
            AudioManager1942.amInstance.PlaySFX(0);
        }

        //Reiniciamos la partida al perder las 3 vidas
        if (lifes <= 0)
        {    
            //Llamamos al método que reinicia el juego
            gmReference.ResetGame();
        }    
    }

    //Método para saber cuando un objeto se ha metido en el Trigger del jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si se ha metido un enemigo, o una bala enemiga
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            //Le restamos una vida al jugador
            lifes--;
            //Actualizamos las vidas en la UI
            uiReference.UpdateLifes(lifes);
            if(lifes > 0)
                //Reproducimos el sonido de muerte del jugador
                AudioManager1942.amInstance.PlaySFX(6);
            //Destruimos la nave enemiga
            Destroy(collision.gameObject);
            //Llamo al método de empezar una nueva vida
            gmReference.AnotherLife();
        }
    }
}
