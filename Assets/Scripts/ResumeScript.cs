using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public string SceneName;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(OnButtonClick);
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
