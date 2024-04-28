using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Camara_Movimiento : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3 (0f,5f,-10f);
    private Jugador_Perro jugador_Perro;
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        //sonido.pitch = 1f;
        jugador_Perro = FindAnyObjectByType<Jugador_Perro>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(!jugador){
            return;
        }
        Vector3 nuevaPos = jugador.position + offset;

        transform.position = Vector3.Lerp(transform.position, nuevaPos, true);


    }
}
