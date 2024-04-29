using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Caida : MonoBehaviour
{
    // Velocidad de ca�da del bloque
    public float cae = 5f;
    // Rango de activaci�n para detectar al jugador
    public float rangoActivacion = 5f;
    // Referencia al Rigidbody2D del bloque
    private Rigidbody2D rb2d;
    // Variable para controlar si el jugador est� cerca del bloque
    private bool jugadorCerca = false;
    // Referencia al script Jugador_Perro para comunicarse con el jugador
    public Jugador_Perro jugador_Perro;

    void Start()
    {
        // Obtener referencia al Rigidbody2D y desactivar la f�sica del bloque al inicio
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
    }

    void Update()
    {
        // Verificar si el jugador est� dentro del rango de activaci�n
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

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        // Verificar si el jugador colision� con el bloque y reducir su vida
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
        // Activa la f�sica del bloque para que comience a caer
        rb2d.isKinematic = false;
        rb2d.velocity = new Vector2(0, -cae);
        // Destruye el bloque despu�s de un tiempo para evitar que quede en la escena
        Destroy(gameObject, 2f);
        // Establece jugadorCerca a true para evitar que se active m�s de una vez
        jugadorCerca = true;
    }
}
