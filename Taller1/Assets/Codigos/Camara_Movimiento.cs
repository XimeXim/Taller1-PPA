using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Camara_Movimiento : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3 (0f,5f,-10f);
    private Manejador_Jugador manejador_Jugador;
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido.pitch = 1f;
        manejador_Jugador = FindAnyObjectByType<Manejador_Jugador>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(!jugador){
            return;
        }
        Vector3 nuevaPos = jugador.position + offset;

        transform.position = Vector3.Lerp(transform.position, nuevaPos, 0);

        if(manejador_Jugador.getVida() == 1){
            sonido.pitch = 2f;
        }

    }
}
