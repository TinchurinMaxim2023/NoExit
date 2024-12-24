using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class left_right_buttons : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public Canvas targetCanvas;
    private Camera targetCamera;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(SwitchCanvas);
        targetCamera = Camera.main;
    }

    void SwitchCanvas()
    {
        StartCoroutine(PlaySoundAndSwitchCanvas());
    }

    IEnumerator PlaySoundAndSwitchCanvas()
    {
        GetComponent<AudioSource>().Play();
        while (GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        var x = targetCanvas.transform.position[0];
        var y = targetCanvas.transform.position[1];
        var z = targetCamera.transform.position[2];
        targetCamera.transform.position = new Vector3(x, y, z);
    }
}
