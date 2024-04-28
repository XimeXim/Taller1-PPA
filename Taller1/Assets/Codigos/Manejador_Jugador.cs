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
   

    public void WinnedGame()
    {
        juegoFinalizado.enabled = true;
    }


    private void ContinuarJuego()
    {

    }
}
