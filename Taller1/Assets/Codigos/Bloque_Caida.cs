using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Caida : MonoBehaviour
{
    public float cae = 5f;
    public float rangoActivacion = 5f; // Cambia este valor seg�n el rango de activaci�n deseado
    private Rigidbody2D rb2d;
    private bool jugadorCerca = false;
    public Jugador_Perro jugador_Perro;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Al inicio, desactiva el Rigidbody2D del bloque
        rb2d.isKinematic = true;
    }

    void Update()
    {
        // Verifica si el jugador est� dentro del rango de activaci�n
        if (!jugadorCerca)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
            if (jugador != null && Vector2.Distance(transform.position, jugador.transform.position) <= rangoActivacion)
            {
                // Activa el bloque cuando el jugador est� dentro del rango de activaci�n
                ActivarBloque();
            }
        }
    }

    public void OnColissionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("Jugador"))
        {
            jugador_Perro = collision2D.gameObject.GetComponent<Jugador_Perro>();
            if (jugador_Perro != null)
            {
                jugador_Perro.PierdeVida();

            }
        }

    }

    void ActivarBloque()
    {
        // Activa la gravedad y el movimiento del Rigidbody2D del bloque
        rb2d.isKinematic = false;
        rb2d.velocity = new Vector2(0, -cae);
        // Destruye el bloque despu�s de un tiempo
        Destroy(gameObject, 2f);
        // Establece jugadorCerca a true para evitar que se active m�s de una vez
        jugadorCerca = true;
    }
}