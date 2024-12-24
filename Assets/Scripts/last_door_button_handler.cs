using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class last_door_button_handler : MonoBehaviour
{
    private Button button;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
    }

    void OnButtonClick()
    {
        StartCoroutine(PlaySoundAndLoadScene());
    }

    IEnumerator PlaySoundAndLoadScene()
    {
        GetComponent<AudioSource>().Play();
        while (GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
    }
}
