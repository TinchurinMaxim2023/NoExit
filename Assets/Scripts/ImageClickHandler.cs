using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    private Button image;
    public Vector3 initialCameraPosition;
    private float initialCameraOrthographicSize;
    private Camera targetCamera;

    void Start()
    {
        targetCamera = Camera.main;
        image = GetComponent<Button>();
        image.interactable = true;
        initialCameraOrthographicSize = targetCamera.orthographicSize;
        image.onClick.AddListener(OnPointerClick);
    }

    public void OnPointerClick()
    {
        //StartCoroutine(PlaySoundAndMoveCamera());
        GetComponent<AudioSource>().Play();
        if (targetCamera.transform.position != initialCameraPosition)
        {
            targetCamera.transform.position = initialCameraPosition;
            targetCamera.orthographicSize = initialCameraOrthographicSize;
        }
        else
        {
            var screenPos = image.transform.position;
            var screenSize = image.GetComponent<RectTransform>().rect.size;
            targetCamera.transform.position = new Vector3(screenPos.x, screenPos.y, targetCamera.transform.position.z);
            targetCamera.orthographicSize = (Mathf.Max(screenSize.x, screenSize.y)) / 3;
        }
    }

    //IEnumerator PlaySoundAndMoveCamera()
    //{
    //    GetComponent<AudioSource>().Play();
    //    while (GetComponent<AudioSource>().isPlaying)
    //    {
    //        yield return null;
    //    }
    //    if (targetCamera.transform.position != initialCameraPosition)
    //    {
    //        targetCamera.transform.position = initialCameraPosition;
    //        targetCamera.orthographicSize = initialCameraOrthographicSize;
    //    }
    //    else
    //    {
    //        var screenPos = image.transform.position;
    //        var screenSize = image.GetComponent<RectTransform>().rect.size;
    //        targetCamera.transform.position = new Vector3(screenPos.x, screenPos.y, targetCamera.transform.position.z);
    //        targetCamera.orthographicSize = (Mathf.Max(screenSize.x, screenSize.y)) / 3;
    //    }
    //}
}
