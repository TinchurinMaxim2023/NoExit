using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tickbuttonscript : MonoBehaviour
{
    public Vector3 initialCameraPosition;
    private Button button;
    public Sprite tick;
    public Image image;
    private Camera targetCamera;
    public bool tick_on;
    public bool is_interactable;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
        image.GetComponent<Image>().sprite = null;
        tick_on = false;
        is_interactable = true;
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
        }
        else
        {
            button.interactable = false;
        }
    }

    void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        if (tick_on)
        {
            tick_on = false;
            image.GetComponent<Image>().sprite = null;
        } else
        {
            tick_on = true;
            image.GetComponent<Image>().sprite = tick;
        }
    }
}
