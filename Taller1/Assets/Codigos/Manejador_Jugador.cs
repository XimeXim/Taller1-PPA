using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manejador_Jugador : MonoBehaviour
{
    // Variable para almacenar el tiempo de pausa restante.
    private float tiempoPausa;

    // Booleano que indica si el juego está en pausa o no.
    private bool juegoEnPausa = false;

    // Referencia al objeto Texto que muestra el mensaje de juego finalizado.
    public Text juegoFinalizado;

    // Referencia al script Manejador_Audio utilizado para controlar el audio del juego.
    public Manejador_Audio manejador_Audio;

    // Método que se llama al iniciar el objeto.
    void Start()
    {
        // Encuentra y asigna una referencia al componente Manejador_Audio en la escena.
        manejador_Audio = FindObjectOfType<Manejador_Audio>();

        // Desactiva el texto de juego finalizado al inicio.
        juegoFinalizado.enabled = false;
    }

    // Método que se llama en cada fotograma.
    void Update()
    {
        // Si el juego está en pausa, disminuye el tiempo de pausa.
        if (juegoEnPausa)
        {
            tiempoPausa -= Time.unscaledDeltaTime;
        }

        // Si el tiempo de pausa llega a cero, continua el juego.
        if (tiempoPausa <= 0)
        {
            ContinuarJuego();
        }
    }

    // Método llamado cuando el jugador gana el juego.
    public void WinnedGame()
    {
        // Activa el texto de juego finalizado para indicar que el juego ha sido ganado.
        juegoFinalizado.enabled = true;
    }

    // Método privado utilizado para continuar el juego después de una pausa.
    private void ContinuarJuego()
    {
        // Aquí puedes agregar la lógica para continuar el juego después de una pausa.
    }
}