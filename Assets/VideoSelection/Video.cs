using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Video : MonoBehaviour, IPointerClickHandler
{
    private Action<Video> _onSelect;

    public void InitVideo(Settings videoSettings)
    {
        _onSelect = videoSettings.OnSelect;
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
