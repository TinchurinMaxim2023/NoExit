using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Application.Quit();
    }
}
