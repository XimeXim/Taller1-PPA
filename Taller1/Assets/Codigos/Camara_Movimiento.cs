using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Camara_Movimiento : MonoBehaviour
{
    // Transform del jugador que la cámara seguirá.
    public Transform jugador;

    // Distancia entre la cámara y el jugador.
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
        // Si no hay un jugador asignado, sale del método.
        if (!jugador)
        {
            return;
        }
        // Si hay un jugador asignado, mueve la cámara para seguir al jugador.
        else if (jugador != null)
        {
            // Calcula la nueva posición de la cámara.
            Vector3 nuevaPos = jugador.position + offset;
            nuevaPos.z = transform.position.z;

            // Mueve suavemente la cámara hacia la nueva posición utilizando Lerp.
            transform.position = Vector3.Lerp(transform.position, nuevaPos, Time.deltaTime * 5f);
        }
    }
}