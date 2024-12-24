using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bars_animation_script : MonoBehaviour
{
    public Vector3 initialCameraPosition;
    private Button button;
    public Canvas canvas;
    public Sprite image;
    private Camera targetCamera;
    public int _currentIndex;
    public float x;
    public float y;
    public float height;
    public Image imageObject;
    public int count;
    public bool is_interactable;
    // Start is called before the first frame update
    void Start()
    {
        _currentIndex = -1;
        targetCamera = Camera.main;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
        imageObject.GetComponent<Image>().sprite = null;
        RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (_currentIndex + 1) * height);
        imageObject.transform.position = new Vector3(x, y + (_currentIndex + 1) * height / 2, 0);
        is_interactable = true;
    }

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

    public void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        if (_currentIndex == count - 1)
        {
            imageObject.GetComponent<Image>().sprite = null;
            _currentIndex = -1;
        } else
        {
            _currentIndex++;
            imageObject.GetComponent<Image>().sprite = image;
        }
        RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (_currentIndex + 1) * height);
        imageObject.transform.position = new Vector3(x, y + (_currentIndex + 1) * height / 2, 0);
    }
}
