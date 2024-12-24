using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockerbuttonsscript : MonoBehaviour
{
    public Vector3 initialCameraPosition;
    private Button button;
    private Camera targetCamera;
    public TMP_Text currentText;
    public TMP_Text targetText;
    public bool is_interactable;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
        is_interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_interactable)
        {
            if (targetCamera.transform.position != initialCameraPosition)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        } else
        {
            button.interactable = false;
        }
    }
    void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        targetText.text += currentText.text;
    }
}
