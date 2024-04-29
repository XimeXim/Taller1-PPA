using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Camara_Movimiento : MonoBehaviour
{
    // Transform del jugador que la c�mara seguir�.
    public Transform jugador;

    // Distancia entre la c�mara y el jugador.
    public Vector3 offset;

    // Referencia al script Jugador_Perro utilizado para interactuar con el jugador perro.
    private Jugador_Perro jugador_Perro;

    // Referencia al AudioSource utilizado para reproducir sonidos.
    public AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene una referencia al script Jugador_Perro en la escena.
        jugador_Perro = FindAnyObjectByType<Jugador_Perro>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si no hay un jugador asignado, sale del m�todo.
        if (!jugador)
        {
            return;
        }
        // Si hay un jugador asignado, mueve la c�mara para seguir al jugador.
        else if (jugador != null)
        {
            // Calcula la nueva posici�n de la c�mara.
            Vector3 nuevaPos = jugador.position + offset;
            nuevaPos.z = transform.position.z;

            // Mueve suavemente la c�mara hacia la nueva posici�n utilizando Lerp.
            transform.position = Vector3.Lerp(transform.position, nuevaPos, Time.deltaTime * 5f);
        }
    }
}