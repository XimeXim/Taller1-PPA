using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre_Abrir : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator del cofre

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Jugador"))
        {
            // Activa la animación de apertura del cofre
            animator.SetTrigger("AbrirCofre");

            // Muestra un mensaje de ganar
            Debug.Log("¡Has ganado!");

            // Desactiva el collider del cofre para evitar que se active más de una vez
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
