using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Smartphone : MonoBehaviour
{
    [SerializeField]
    private Image _screen; 

    [SerializeField]
    private TextMeshProUGUI _title;

    [SerializeField]
    private Image _uploaderImage;

    [SerializeField]
    private TextMeshProUGUI _uploaderName;

    public void SetPlayingVideo(Video video)
    {
        _screen.sprite = video.VideoImage;
        _screen.color = Color.white;
        _title.text = video.Title;
        _uploaderImage.sprite = video.UploaderImage;
        _uploaderImage.color = Color.white;
        _uploaderName.text = video.UploaderName;
    }
}
