using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manejador_Audio : MonoBehaviour
{
    // Arreglo que contiene los clips de audio disponibles.
    public AudioClip[] sonidos;

    // Referencia al componente AudioSource que reproducir� los sonidos.
    public AudioSource sonido;

    // M�todo que se llama al iniciar el objeto.
    void Start()
    {
        // No se realiza ninguna acci�n en este m�todo en este momento.
    }

    // M�todo que se llama en cada fotograma.
    void Update()
    {
        // No se realiza ninguna acci�n en este m�todo en este momento.
    }

    // M�todo para reproducir un sonido espec�fico del arreglo.
    // Par�metros:
    // - index: El �ndice del sonido en el arreglo 'sonidos' que se va a reproducir.
    // - vol: El volumen del sonido (valor entre 0 y 1).
    // - LoopTrue: Un booleano que indica si el sonido debe repetirse en bucle.
    public void play(int index, float vol, bool LoopTrue)
    {
        // Asigna el clip de audio correspondiente al AudioSource.
        sonido.clip = sonidos[index];

        // Establece el volumen del sonido.
        sonido.volume = vol;

        // Establece si el sonido se repetir� en bucle o no.
        sonido.loop = LoopTrue;

        // Reproduce el sonido.
        sonido.Play();
    }

    // M�todo para detener la reproducci�n del sonido actual.
    public void stop()
    {
        // Detiene la reproducci�n del sonido.
        sonido.Stop();
    }
}