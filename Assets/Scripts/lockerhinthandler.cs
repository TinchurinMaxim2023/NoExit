using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockerhinthandler : MonoBehaviour
{
    public TMP_Text targetText;
    public Button[] buttons;
    public Button[] locker_buttons;
    private bool[] answers;
    private Button cur_button;
    public Vector3 initialCameraPosition;
    private float initialCameraOrthographicSize;
    private Camera targetCamera;
    private string hint;
    private bool right_answer;
    [SerializeField] private AudioClip press_soundClip;
    // Start is called before the first frame update
    void Start()
    {
        answers = new bool[] { false, true, false, false, true, false, false, true, true};
        cur_button = GetComponent<Button>();
        cur_button.interactable = false;
        targetCamera = Camera.main;
        initialCameraOrthographicSize = targetCamera.orthographicSize;
        cur_button.onClick.AddListener(OnPointerClick);
        hint = "Охранники. Заключённые. Начальник.";
        right_answer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!right_answer)
        {
            bool flag = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = buttons[i];
                var script = button.GetComponent<tickbuttonscript>();
                if (script.tick_on != answers[i])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                GetComponent<AudioSource>().Play();
                right_answer = true;
                cur_button.interactable = true;
                for (int i = 0; i < buttons.Length; i++)
                {
                    Button button = buttons[i];
                    var script = button.GetComponent<tickbuttonscript>();
                    script.is_interactable = false;
                }
                cur_button.GetComponent<Image>().sprite = null;
                targetText.text = hint;
                targetText.color = Color.black;
                for (int i = 0; i < locker_buttons.Length; i++)
                {
                    Button button = locker_buttons[i];
                    var script = button.GetComponent<lockerbuttonsscript>();
                    script.is_interactable = true;
                }
            }
        }
    }

    public void OnPointerClick()
    {
        GetComponent<AudioSource>().clip = press_soundClip;
        GetComponent<AudioSource>().Play();
        if (targetCamera.transform.position != initialCameraPosition)
        {
            targetCamera.transform.position = initialCameraPosition;
            targetCamera.orthographicSize = initialCameraOrthographicSize;
        }
        else
        {
            var screenPos = cur_button.transform.position;
            var screenSize = cur_button.GetComponent<RectTransform>().rect.size;
            targetCamera.transform.position = new Vector3(screenPos.x, screenPos.y, targetCamera.transform.position.z);
            targetCamera.orthographicSize = (Mathf.Max(screenSize.x, screenSize.y)) / 3;
        }
    }
}
