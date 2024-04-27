using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manejador_Jugador : MonoBehaviour
{
    public float velocidadMovimento = 5f;
    public int tipoMovimiento;

    private Rigidbody2D rb2D;

    public int vida;
    private float tiempoPausa;
    private bool juegoEnPausa = false;
    public Text juegoFinalizado;
    public Manejador_Audio manejador_Audio;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
     
        vida = 2;
        manejador_Audio = FindObjectOfType<Manejador_Audio>();
        juegoFinalizado.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(juegoEnPausa){
            tiempoPausa -= Time.unscaledDeltaTime;
        }
        if(tiempoPausa <= 0){
            ContinuarJuego();
        }
        
    }

    public int getVida()
    {
        return vida;
    }
    public void VidaPerdida()
    {
        vida -=1;
        if(vida == 0){
            manejador_Audio.play(3, 0.5f, false);
            SceneManager.LoadScene(0);
        }
    }

    public void WinnedGame()
    {
        juegoFinalizado.enabled = true;
    }


    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);
        
        Debug.Log(movimientoHorizontal+"   "+movimientoVertical);

        if(tipoMovimiento == 1)
        {
            transform.Translate(movimiento * velocidadMovimento * Time.deltaTime);
        }else if(tipoMovimiento == 2)
        {
            rb2D.velocity = movimiento * velocidadMovimento;
        }
        else
        {
            rb2D.AddForce(movimiento * velocidadMovimento);
        }
    }

    private void ContinuarJuego()
    {

    }
}
