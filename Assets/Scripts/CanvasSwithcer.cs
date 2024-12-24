using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas targetCanvas;

    public void SwitchCanvas()
    {
        // Отключить все холсты
        Canvas[] allCanvases = FindObjectsOfType<Canvas>();
        Debug.Log(targetCanvas);
        foreach (Canvas canvas in allCanvases)
        {
            canvas.enabled = false;
        }

        // Включить целевой холст
        targetCanvas.enabled = true;
    }
}
