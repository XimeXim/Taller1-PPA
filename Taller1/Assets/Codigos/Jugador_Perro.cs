using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Perro : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public int tipoMovimiento;
    public float fuerzaSalto = 8f;
    public int vidaMaxima = 2;
    private int monedasRecolectadas;
    private int monedasWin = 14;

    private Rigidbody2D rb2d;
    private Animator animator;
    private int vidaActual;
    private bool enSuelo;
    private Manejador_Audio manejador_Audio;
    public Moneda_Recolector moneda_Recolector;
    private Manejador_Jugador manejador_Jugador;
    public AudioSource sonido;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
        

    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        if (tipoMovimiento ==1)
        {
            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
        }else if(tipoMovimiento == 2)
        {
            rb2d.velocity = movimiento * velocidadMovimiento;
        }
        else
        {
            rb2d.AddForce(movimiento * velocidadMovimiento);
        }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Moneda"))
        {
            moneda_Recolector.ComerMoneda();
            monedasRecolectadas++;
        }
        else if (collider.CompareTag("Cofre") && monedasRecolectadas == monedasWin)
        {
            //abrir cofre y mensaje de juego ganado
        }
    }


    public void PierdeVida()
    {
        vidaActual--;
        animator.SetTrigger("Herido");
        manejador_Audio.play(2, 0.5f, false);

        if (vidaActual == 1)
        {
            sonido.pitch = 2f;
        }
        else if (vidaActual <= 0)
        {
            //Reiniciar la escena
        }
    }

    public void Saltar()
    {
        rb2d.velocity = Vector2.up * fuerzaSalto;
    }
 
}

