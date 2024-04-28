using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manejador_Jugador : MonoBehaviour
{
    
    private float tiempoPausa;
    private bool juegoEnPausa = false;
    public Text juegoFinalizado;
    public Manejador_Audio manejador_Audio;

    // Start is called before the first frame update
    void Start()
    {
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
  /* private void FixedUpdate() 
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        if(tipoMovimiento ==1)
        {
            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }
  */
    public void WinnedGame()
    {
        juegoFinalizado.enabled = true;
    }


    private void ContinuarJuego()
    {

    }
}
