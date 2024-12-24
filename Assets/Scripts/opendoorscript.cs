using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class opendoorscript : MonoBehaviour
{
    private Button button;
    public Button locker;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        var script = locker.GetComponent<lockerhandler>();
        button.interactable = script.can_open;
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
