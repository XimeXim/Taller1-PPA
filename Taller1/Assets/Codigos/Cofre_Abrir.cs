using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre_Abrir : MonoBehaviour
{
    // Referencia al componente Animator del cofre.
    public Animator animator;

    // Método llamado cuando un objeto entra en contacto con el collider del cofre.
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        // Verifica si el objeto que entra en contacto tiene la etiqueta "Jugador".
        if (collider2D.CompareTag("Jugador"))
        {
            // Activa la animación de apertura del cofre.
            animator.SetTrigger("AbrirCofre");

            // Muestra un mensaje de ganar en la consola.
            Debug.Log("¡Has ganado!");

            // Desactiva el collider del cofre para evitar que se active más de una vez.
            GetComponent<Collider2D>().enabled = false;
        }
    }
}