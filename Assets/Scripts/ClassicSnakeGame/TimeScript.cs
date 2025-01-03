using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Créditos: ChatGPT
public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Arrastra aquí el objeto de texto en el Inspector
    private float elapsedTime;  // Tiempo acumulado

    void Update()
    {
        // Incrementar el tiempo
        elapsedTime += Time.deltaTime;

        // Formatear y mostrar el tiempo
        timerText.text = FormatTime(elapsedTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60); // Minutos
        int seconds = Mathf.FloorToInt(time % 60); // Segundos
        return string.Format("TIME: {0:00}:{1:00}", minutes, seconds); // Formato MM:SS
    }
}
