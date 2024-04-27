using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manejador_Audio : MonoBehaviour
{
    public AudioClip [] sonidos;
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(int index, float vol, bool LoopTrue)
    {
        sonido.clip =sonidos[index];
        sonido.volume = vol;
        sonido.loop = LoopTrue;
        sonido.Play();
    }

    public void stop()
    {
        sonido.Stop();
    }
}