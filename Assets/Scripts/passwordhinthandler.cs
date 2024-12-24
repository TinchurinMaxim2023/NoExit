using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passwordhinthandler : MonoBehaviour
{
    public TMP_Text targetText;
    public Button locker_button;
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
        cur_button = GetComponent<Button>();
        cur_button.interactable = false;
        targetCamera = Camera.main;
        initialCameraOrthographicSize = targetCamera.orthographicSize;
        cur_button.onClick.AddListener(OnPointerClick);
        hint = "Ïאנמכü םאמבמנמע: 42022142";
        right_answer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!right_answer)
        {
            var locker_script = locker_button.GetComponent<figurespuzzlehandler>();
            if (locker_script.can_open)
            {
                GetComponent<AudioSource>().Play();
                right_answer = true;
                cur_button.interactable = true;
                cur_button.GetComponent<Image>().sprite = null;
                targetText.text = hint;
                targetText.color = Color.black;
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
