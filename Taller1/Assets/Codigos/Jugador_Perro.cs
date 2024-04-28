using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Perro : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;
    public int vidaMaxima = 2;
    private int monedasRecolectadas;
    private int monedasWin = 14;

    private Rigidbody2D rb2d;
    private Animator animator;
    private int vidaActual;
    private bool enSuelo;
    private Manejador_Audio manejador_Audio;
    private Moneda_Recolector moneda_Recolector;
    private Manejador_Jugador manejador_Jugador;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void alChocar(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            PierdeVida();
        }
    }

    public void OnTrigger(Collider2D collider)
    {
        if (collider.CompareTag("Moneda"))
        {
            monedasRecolectadas++;
            moneda_Recolector.OnTriggerEnter2D(collider);
        }else if(collider.CompareTag("Cofre") && monedasRecolectadas == monedasWin)
        {
            //abrir cofre y mensaje de juego ganado
        }
    }
    
    public void PierdeVida()
    {
        vidaActual--;
        animator.SetTrigger("Herido");
        manejador_Audio.play(2, 0.5f, false);
        if(vidaActual <= 0)
        {
            //Reiniciar la escena
        }
    }

}
