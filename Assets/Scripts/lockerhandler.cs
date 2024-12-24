using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockerhandler : MonoBehaviour
{
    public Button[] turners;
    public Button[] buttons;
    private int[] correct_positions;
    private string locker_answer;
    public bool right_answer;
    public bool can_open;
    // Start is called before the first frame update
    void Start()
    {
        correct_positions = new int[] { 1, 0, 1, 1, 0 };
        locker_answer = "212";
        TMP_Text buttonText = GetComponentInChildren<TMP_Text>();
        buttonText.text = "";
        right_answer = false;
        can_open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!right_answer)
        {
            bool flag = true;
            for (int i = 0; i < turners.Length; i++)
            {
                Button turner = turners[i];
                var script = turner.GetComponent<switchersscript>();
                if (script.cur_position != correct_positions[i])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                GetComponent<AudioSource>().Play();
                right_answer = true;
                for (int i = 0; i < buttons.Length; i++)
                {
                    Button button = buttons[i];
                    var script = button.GetComponent<lockerbuttonsscript>();
                    script.is_interactable = true;
                }
            }
        }

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
