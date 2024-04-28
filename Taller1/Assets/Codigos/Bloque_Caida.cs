using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Caida : MonoBehaviour
{
    
    public float cae = 5f;
    public float distanciaJugador = 3f;
    private Rigidbody2D rb2d;
    private bool jugadorCerca = false;
    private bool cayo = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (!jugadorCerca && !cayo)
        {
            Caer();
            cayo = true;
        }
    }

   /* public void OnColissionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("Jugador"))
        {
            jugador_Perro = collision2D.gameObject.GetComponent<Jugador_Perro>();
            if (jugador_Perro != null)
            {
                jugador_Perro.PierdeVida();

            }
        }

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            jugadorCerca = true;
        }
    }


    public void Caer()
    {
        rb2d.velocity = new Vector2(0, -cae);
        Destroy(gameObject, 2f);
    }

}
