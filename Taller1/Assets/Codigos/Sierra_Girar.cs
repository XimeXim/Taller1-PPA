using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra_Girar : MonoBehaviour
{
    // Velocidad de rotaci�n de la sierra.
    public float velocidadGiro = 100f;

    // Referencia al script Jugador_Perro utilizado para interactuar con el jugador perro.
    public Jugador_Perro jugador_Perro;

    // M�todo que se llama al iniciar el objeto.
    void Start()
    {
        // No se realiza ninguna acci�n en este m�todo en este momento.
    }

    // M�todo que se llama en cada fotograma.
    void Update()
    {
        // Rota la sierra en el eje z a una velocidad constante.
        transform.Rotate(0f, 0f, velocidadGiro * Time.deltaTime);
    }

    // M�todo llamado cuando un objeto colisiona con esta sierra.
    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Jugador".
        if (collision2D.gameObject.CompareTag("Jugador"))
        {
            // Obtiene una referencia al script Jugador_Perro del jugador.
            jugador_Perro = collision2D.gameObject.GetComponent<Jugador_Perro>();
            // Si el jugador perro existe, llama al m�todo PierdeVida para hacerle perder una vida.
            if (jugador_Perro != null)
            {
                jugador_Perro.PierdeVida();
            }
        }
    }
}