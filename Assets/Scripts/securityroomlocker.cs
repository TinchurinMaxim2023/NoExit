using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class securityroomlocker : MonoBehaviour
{
    public Button[] buttons;
    private string locker_answer;
    public bool can_open;
    // Start is called before the first frame update
    void Start()
    {
        locker_answer = "371";
        TMP_Text buttonText = GetComponentInChildren<TMP_Text>();
        buttonText.text = "";
        can_open = false;
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
                    buttonText.color = Color.green;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        Button button = buttons[i];
                        var script = button.GetComponent<lockerbuttonsscript>();
                        script.is_interactable = false;
                    }
                }
                else
                {
                    buttonText.text = "";
                }
            }
        }
    }
}
