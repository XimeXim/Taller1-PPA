using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manejador_Audio : MonoBehaviour
{
    // Arreglo que contiene los clips de audio disponibles.
    public AudioClip[] sonidos;

    // Referencia al componente AudioSource que reproducirá los sonidos.
    public AudioSource sonido;

    // Método que se llama al iniciar el objeto.
    void Start()
    {
        // No se realiza ninguna acción en este método en este momento.
    }

    // Método que se llama en cada fotograma.
    void Update()
    {
        // No se realiza ninguna acción en este método en este momento.
    }

    // Método para reproducir un sonido específico del arreglo.
    // Parámetros:
    // - index: El índice del sonido en el arreglo 'sonidos' que se va a reproducir.
    // - vol: El volumen del sonido (valor entre 0 y 1).
    // - LoopTrue: Un booleano que indica si el sonido debe repetirse en bucle.
    public void play(int index, float vol, bool LoopTrue)
    {
        // Asigna el clip de audio correspondiente al AudioSource.
        sonido.clip = sonidos[index];

        // Establece el volumen del sonido.
        sonido.volume = vol;

        // Establece si el sonido se repetirá en bucle o no.
        sonido.loop = LoopTrue;

        // Reproduce el sonido.
        sonido.Play();
    }

    // Método para detener la reproducción del sonido actual.
    public void stop()
    {
        // Detiene la reproducción del sonido.
        sonido.Stop();
    }
}