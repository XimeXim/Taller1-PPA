using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra_Girar : MonoBehaviour
{
    public float velocidadGiro = 100f;
    public Jugador_Perro jugador_Perro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f, velocidadGiro * Time.deltaTime);   
    }

    public void OnColissionEnter2D(Collision2D collision2D)
    {
        
        if (collision2D.gameObject.CompareTag("Jugador"))
        {
            jugador_Perro = collision2D.gameObject.GetComponent<Jugador_Perro>();
            if(jugador_Perro != null)
            {
                jugador_Perro.PierdeVida();

            }
        }

    }
}
