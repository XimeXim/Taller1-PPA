using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda_Recolector : MonoBehaviour
{
    public Manejador_Audio manejadorAudio;
    public int valorMoneda = 1;
    public Jugador_Perro jugador_Perro;


    // Start is called before the first frame update
    void Start()
    {
        manejadorAudio = FindObjectOfType<Manejador_Audio>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            // manejadorAudio.play(0, 0.5f, false);
            AudioSource audioSource = collision.GetComponent<AudioSource>(); // Obtén el AudioSource del perro
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip); // Reproduce el clip de audio del perro
            }
            Destroy(gameObject);
            //actualizar HUD con las monedas que faltan y el sonido de moneda
        }
    }

}
