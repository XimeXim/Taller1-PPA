using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text monedasTotalesText;
    public Text monedasFaltantesText;
    private int monedasFaltantes;

    void Start()
    {
        monedasFaltantes = 14;
        ActualizarHUD();
    }

    public void RecolectarMoneda()
    {
        monedasFaltantes--;
        ActualizarHUD();
    }

    void ActualizarHUD()
    {
        monedasTotalesText.text = "Monedas Totales: 14";
        monedasFaltantesText.text = "Monedas Faltantes: " + monedasFaltantes;
    }
}
