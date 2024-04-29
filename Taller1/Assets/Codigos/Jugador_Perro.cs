using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador_Perro : MonoBehaviour
{
    // Variables públicas para ajustar el comportamiento del jugador
    public float velocidadMovimiento = 5f;
    public int tipoMovimiento;
    public float fuerzaSalto = 8f;
    public int vidaMaxima = 2;
    public int monedasRecolectadas;

    // Referencias a los objetos de texto para mostrar la cantidad de monedas y vidas
    public Text marcadorMonedas;
    public Text marcadorVidas;

    // Animator para controlar las animaciones del jugador y del cofre
    public Animator cofreAnimator;

    // Referencias a componentes necesarios
    private Rigidbody2D rb2d;
    private Animator animator;
    private int vidaActual;
    private Manejador_Audio manejador_Audio;
    private Manejador_Jugador manejador_Jugador;
    public AudioSource sonido;

    // Valor constante para el número de monedas necesarias para ganar
    private int monedasWin = 14;

    void Start()
    {
        // Obtener referencias a componentes al comienzo
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla de espacio, el jugador salta.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    //
    // Método utilizado para actualizar el marcador de monedas.
    public void getMonedasRecolectadas()
    {
        marcadorMonedas.text = "    " + monedasRecolectadas.ToString() + "/14";
    }

    // Método utilizado para mostrar las vidas restantes del jugador.
    public void ShowVidas()
    {
        marcadorMonedas.text = "    " + vidaActual.ToString();
    }

    private void FixedUpdate()
    {
        // Obtiene el movimiento horizontal y vertical del jugador.
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento.
        Vector3 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Realiza el movimiento según el tipo de movimiento especificado.
        if (tipoMovimiento == 1)
        {
            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        else if (tipoMovimiento == 2)
        {
            rb2d.velocity = movimiento * velocidadMovimiento;
        }
        else
        {
            rb2d.AddForce(movimiento * velocidadMovimiento);
        }

    }

    // Método llamado cuando un objeto entra en contacto con el jugador.
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica el tipo de objeto con el que el jugador entra en contacto y realiza acciones correspondientes.
        if (collider.CompareTag("Moneda"))
        {
            monedasRecolectadas++;
            getMonedasRecolectadas();
        }
        else if (collider.CompareTag("Enemigo"))
        {
            ShowVidas();
        }
        else if (collider.CompareTag("Cofre") && monedasRecolectadas == monedasWin)
        {
            cofreAnimator.SetTrigger("AbrirCofre");
        }

    }

    // Método para reducir la vida del jugador.
    public void PierdeVida()
    {
        vidaActual--;
        animator.SetTrigger("Herido");
        manejador_Audio.play(2, 0.5f, false);

        // Ajusta el tono del sonido según la vida actual del jugador.
        if (vidaActual == 1)
        {
            sonido.pitch = 2f;
        }
        else if (vidaActual <= 0)
        {
            // Reiniciar la escena o realizar acciones de juego over.
        }
    }

    // Método para que el jugador realice un salto.
    public void Saltar()
    {
        rb2d.velocity = Vector2.up * fuerzaSalto;
    }
}