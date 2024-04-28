using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Caida : MonoBehaviour
{
    public float cae = 2f;
    private bool esCaer = false;
    private Jugador_Perro jugador_Perro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnColissionEnter2D(Collision2D collision2D)
    {
        
        if (collision2D.gameObject.CompareTag("Jugador"))
        {
            jugador_Perro = collision2D.gameObject.GetComponent<Jugador_Perro>();
            if (jugador_Perro != null)
            {
                jugador_Perro.PierdeVida();
            }
        }else if (!esCaer)
        {
            esCaer = true;
            Invoke("Caer", cae);
        }

    }

    public void Caer()
    {
        Destroy(gameObject, 2f);
    }
}
