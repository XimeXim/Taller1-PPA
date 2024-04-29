using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizadorTexto : MonoBehaviour
{
    private Camera camara_Movimiento;
    private RectTransform rectTransform;
    public Jugador_Perro jugador_perro;
    private Text texto;
    // Start is called before the first frame update
    void Start()
    {
        camara_Movimiento = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camara_Movimiento != null && rectTransform != null)
        {
            Vector3 posicionCamara = camara_Movimiento.transform.position;
            Vector2 posicionPantalla = camara_Movimiento.WorldToScreenPoint(posicionCamara);
            rectTransform.position = posicionPantalla;
            texto.text = jugador_perro.getMonedasRecolectadas() + "/ 14";
        }


    }
}
