using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchersscript : MonoBehaviour
{
    public Vector3 initialCameraPosition;
    public Sprite off_position;
    public Sprite on_position;
    public int cur_position;
    private Button button;
    public Button locker;
    private Camera targetCamera;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main;
        cur_position = 0;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
    }

    void Update()
    {
        var script = locker.GetComponent<lockerhandler>();
        if (!script.right_answer)
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

    void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        if (cur_position == 0)
        {
            button.GetComponent<Image>().sprite = on_position;
            cur_position = 1;
        }
        else
        {
            button.GetComponent<Image>().sprite = off_position;
            cur_position = 0;
        }
    }
}
