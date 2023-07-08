using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Video : MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    [SerializeField]
    private VideoResource _videoResource;

    public Sprite Thumbnail => _videoResource.Thumbnail;
    public Sprite VideoImage => _videoResource.VideoImage;
    public string Title => _videoResource.Title;
    public Sprite UploaderImage => _videoResource.UploadedImage;
    public string UploaderName => _videoResource.UploaderName;
    public AudioClip Audio => _videoResource.Audio;

    private Action<Video> _onSelect;

    public void InitVideo(Settings videoSettings)
    {
        _onSelect = videoSettings.OnSelect;
    }

    public void Awake()
    {
        Image.sprite = Thumbnail;
        Image.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Clicked video!");

            if (_onSelect != null)
            {
                _onSelect(this);
            }
            else
            {
                Debug.Log("no callback for clicking video");
            }
        }
    }

    public class Settings
    {
        public Action<Video> OnSelect;
    }
}
