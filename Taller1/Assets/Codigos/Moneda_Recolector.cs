using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda_Recolector : MonoBehaviour
{
    // Referencia al script Manejador_Audio utilizado para controlar el audio del juego.
    public Manejador_Audio manejadorAudio;

    // Referencia al script Jugador_Perro utilizado para interactuar con el jugador perro.
    public Jugador_Perro jugador_Perro;

    // Referencia al objeto Texto que muestra el marcador de monedas.
    public Text marcadorMonedas;

    // Método que se llama al iniciar el objeto.
    void Start()
    {
        // Encuentra y asigna una referencia al componente Manejador_Audio en la escena.
        manejadorAudio = FindObjectOfType<Manejador_Audio>();
    }

    // Método que se llama en cada fotograma.
    void Update()
    {
        // No se realiza ninguna acción en este método en este momento.
    }

    // Método llamado cuando un objeto entra en el área de activación de este objeto.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra en contacto tiene la etiqueta "Jugador".
        if (collision.CompareTag("Jugador"))
        {
            // Obtiene el componente AudioSource del jugador.
            AudioSource audioSource = collision.GetComponent<AudioSource>();
            // Si el componente y su clip de audio asociado existen, reproduce el clip de audio.
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            // Llama al método getMonedasRecolectadas del jugador perro para incrementar el contador de monedas recolectadas.
            jugador_Perro.getMonedasRecolectadas();
            // Destruye este objeto (la moneda recolectada).
            Destroy(gameObject);
            // Aquí puedes agregar la lógica para actualizar el HUD con las monedas restantes y el sonido de moneda.
        }
    }
}