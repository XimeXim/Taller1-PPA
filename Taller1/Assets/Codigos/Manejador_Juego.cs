using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manejador_Juego : MonoBehaviour
{
    public int vida;
    private float tiempoPausa;
    private bool juegoEnPausa = false;
    public Text juegoFinalizado;
    public Manejador_Audio manejador_Audio;

    // Start is called before the first frame update
    void Start()
    {
        vida = 2;
        manejador_Audio = FindObjectOfType<Manejador_Audio>();
        juegoFinalizado.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(juegoEnPausa){
            //tiempoPausa -= Tiempo.unscaledDeltaTime;
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


}
