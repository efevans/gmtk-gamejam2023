using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FrugalTime.Playable
{
    public class Video : MonoBehaviour, IPointerClickHandler
    {
        public Image Image;
        public Image Lock;
        public Image PlayingNow;

        [SerializeField]
        private VideoResource _videoResource;

        public Sprite Thumbnail => _videoResource.Thumbnail;
        public Sprite VideoImage => _videoResource.VideoImage;
        public string Title => _videoResource.Title;
        public Sprite UploaderImage => _videoResource.UploadedImage;
        public string UploaderName => _videoResource.UploaderName;
        public AudioClip Audio => _videoResource.Audio;
        public IReadOnlyList<Genre> Genres => _videoResource.GenreList.AsReadOnly();

        public Action<Video> OnSelect;

        private VideoState _state;

        public void InitVideo(Settings videoSettings)
        {
            OnSelect = videoSettings.OnSelect;
            _state.Enable();
        }

        public void Enable()
        {
            _state.Enable();
        }

        public void Disable()
        {
            _state.Disable();
        }

        public void Awake()
        {
            Image.sprite = Thumbnail;
            Image.color = Color.white;
            SetState(new DisabledState(this));
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                _state.OnSelect();
            }
        }

        public void SetState(VideoState videoState)
        {
            _state = videoState;
            _state.Start();
        }

        public enum Genre
        {
            Cute,
            Funny,
            Cool,
            VideoGame,
            Informative,
            News,
            Sports,
            Horrific,
            Action,
            Exotic,
            Unique,
            Disgusting,
            ASMR,
            Chill,
            SelfImprovement
        }

        public class Settings
        {
            public Action<Video> OnSelect;
        }
    } 
}
