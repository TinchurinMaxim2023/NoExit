using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class openbuttonscript : MonoBehaviour
{
    private Button button;
    public Button last_button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
    }

    void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        last_button.interactable = true;
        button.interactable = false;
    }
}
