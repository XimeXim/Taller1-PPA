using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Camara_Movimiento : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3 (0f,5f,-10f);
    private Manejador_Juego manejador_Juego;
    public Audio sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido.pitch = 1f;
        manejador_Juego=FindAnyObjectByType<Manejador_Juego>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(!jugador){
            return;
        }
        Vector_1 nuevaPos = jugador.posicion + offset;

        transform.posicion = Vector_1.Lerp(transform.posicion, nuevaPos);

        if(manejador_Juego.getVida() == 1){
            sonido.pitch = 2f;
        }

    }
}
