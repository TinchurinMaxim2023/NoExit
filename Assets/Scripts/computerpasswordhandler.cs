using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class computerpasswordhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] buttons;
    private string locker_answer;
    public bool can_open;
    public TMP_Text[] texts;
    public Sprite New_screen_sprite;
    public Sprite open_button_sprite;
    public Button open_button;
    private string new_text;

    // Start is called before the first frame update
    void Start()
    {
        locker_answer = "24122024";
        TMP_Text buttonText = GetComponentInChildren<TMP_Text>();
        buttonText.text = "";
        can_open = false;
        new_text = "Разблокировать дверь";
    }

    // Update is called once per frame
    void Update()
    {
        if (!can_open)
        {
            TMP_Text buttonText = GetComponentInChildren<TMP_Text>();
            if (buttonText.text.Length == locker_answer.Length)
            {
                if (buttonText.text == locker_answer)
                {
                    can_open = true;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        Button button = buttons[i];
                        Destroy(button.gameObject);
                    }
                    for (int i = 0; i < texts.Length; i++)
                    {
                        var text = texts[i];
                        Destroy(text.gameObject);
                    }
                    
                    GetComponent<Image>().sprite = New_screen_sprite;
                    open_button.GetComponent<Image>().sprite = open_button_sprite;
                    open_button.GetComponentInChildren<TMP_Text>().text = new_text;
                    open_button.interactable = true;

                }
                buttonText.text = "";
            }
        }
    }
}
