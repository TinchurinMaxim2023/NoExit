using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointersscript : MonoBehaviour
{
    public Sprite image;
    public Button[] buttons;
    private int[] answers;
    private Button cur_button;
    public Vector3 initialCameraPosition;
    private float initialCameraOrthographicSize;
    private Camera targetCamera;
    [SerializeField] private AudioClip press_soundClip;
    private bool right_answer;
    //Start is called before the first frame update
    void Start()
    {
        answers = new int[] { 4, 1, 3, 5, 2 };
        cur_button = GetComponent<Button>();
        cur_button.interactable = false;
        targetCamera = Camera.main;
        initialCameraOrthographicSize = targetCamera.orthographicSize;
        cur_button.onClick.AddListener(OnPointerClick);
        right_answer = false;
    }

    //Update is called once per frame
    void Update()
    {
        if (!right_answer)
        {
            bool flag = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = buttons[i];
                var script = button.GetComponent<bars_animation_script>();
                if (script._currentIndex + 1 != answers[i])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                right_answer = true;
                GetComponent<AudioSource>().Play();
                cur_button.interactable = true;
                for (int i = 0; i < buttons.Length; i++)
                {
                    Button button = buttons[i];
                    var script = button.GetComponent<bars_animation_script>();
                    script.is_interactable = false;
                }
                cur_button.GetComponent<Image>().sprite = image;
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
